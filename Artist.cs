using System;
using Grammophone.Domos.Domain;

namespace Grammophone.Domos.Tests.Music.Domain
{
	/// <summary>
	/// Artist in a record label.
	/// </summary>
	[Serializable]
	public class Artist : EntityWithID<long>, ISegregatedEntity<MusicUser, RecordLabel>
	{
		/// <summary>The artist name.</summary>
		public virtual string Name { get; set; }

		/// <summary>The record label ID.</summary>
		public virtual long RecordLabelID { get; set; }

		/// <summary>The record label.</summary>
		public virtual RecordLabel RecordLabel { get; set; }

		/// <inheritdoc/>
		long ISegregatedEntity.SegregationID => this.RecordLabelID;

		/// <inheritdoc/>
		RecordLabel ISegregatedEntity<MusicUser, RecordLabel>.Segregation => this.RecordLabel;
	}
}
