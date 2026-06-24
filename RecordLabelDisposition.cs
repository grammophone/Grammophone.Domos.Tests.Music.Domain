using System;
using System.ComponentModel.DataAnnotations.Schema;
using Grammophone.Domos.Domain;

namespace Grammophone.Domos.Tests.Music.Domain
{
	/// <summary>
	/// Base class for dispositions scoped to a record label.
	/// </summary>
	[Serializable]
	public abstract class RecordLabelDisposition : Disposition, IDisposition<MusicUser, RecordLabel>
	{
		/// <inheritdoc/>
		public override long SegregationID => RecordLabelID;

		/// <summary>
		/// The record label ID.
		/// </summary>
		public virtual long RecordLabelID { get; set; }

		/// <summary>
		/// The record label.
		/// </summary>
		[ForeignKey(nameof(RecordLabelID))]
		public virtual RecordLabel RecordLabel { get; set; }

		/// <summary>
		/// The owning music user.
		/// </summary>
		public virtual MusicUser User
		{
			get => (MusicUser)this.OwningUser;
			set => this.OwningUser = value;
		}

		/// <inheritdoc/>
		RecordLabel ISegregatedEntity<MusicUser, RecordLabel>.Segregation => this.RecordLabel;

		/// <inheritdoc/>
		public void SetSegregation(RecordLabel segregation)
		{
			this.RecordLabel = segregation ?? throw new ArgumentNullException(nameof(segregation));
			this.RecordLabelID = segregation.ID;
		}
	}
}
