using System;
using Grammophone.Domos.Domain;

namespace Grammophone.Domos.Tests.Music.Domain
{
	/// <summary>
	/// Track in an album.
	/// </summary>
	[Serializable]
	public class Track : EntityWithID<long>, ISegregatedEntity<MusicUser, RecordLabel>, IOwnedEntity<MusicUser>
	{
		/// <summary>The track title.</summary>
		public virtual string Title { get; set; }

		/// <summary>The album ID.</summary>
		public virtual long AlbumID { get; set; }

		/// <summary>The album.</summary>
		public virtual Album Album { get; set; }

		/// <summary>The record label ID.</summary>
		public virtual long RecordLabelID { get; set; }

		/// <summary>The record label.</summary>
		public virtual RecordLabel RecordLabel { get; set; }

		/// <summary>The owning user ID.</summary>
		public virtual long OwnerID { get; set; }

		/// <summary>The owning user.</summary>
		public virtual MusicUser Owner { get; set; }

		/// <inheritdoc/>
		long ISegregatedEntity.SegregationID => this.RecordLabelID;

		/// <inheritdoc/>
		RecordLabel ISegregatedEntity<MusicUser, RecordLabel>.Segregation => this.RecordLabel;

		/// <inheritdoc/>
		public bool IsOwnedBy(MusicUser user) => user != null && user.ID == this.OwnerID;
	}
}
