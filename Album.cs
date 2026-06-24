using System;
using System.Collections.Generic;
using Grammophone.Domos.Domain;
using Grammophone.Domos.Domain.Workflow;
using Grammophone.GenericContentModel;

namespace Grammophone.Domos.Tests.Music.Domain
{
	/// <summary>
	/// Album in a record label.
	/// </summary>
	[Serializable]
	public class Album : TrackingEntityWithID<MusicUser, long>, ISegregatedEntity<MusicUser, RecordLabel>, IOwnedEntity<MusicUser>, IStateful<MusicUser, AlbumStateTransition>
	{
		private ICollection<Track> tracks;

		private ICollection<AlbumStateTransition> stateTransitions;

		/// <summary>The album title.</summary>
		public virtual string Title { get; set; }

		/// <summary>The artist ID.</summary>
		public virtual long ArtistID { get; set; }

		/// <summary>The artist.</summary>
		public virtual Artist Artist { get; set; }

		/// <summary>The record label ID.</summary>
		public virtual long RecordLabelID { get; set; }

		/// <summary>The record label.</summary>
		public virtual RecordLabel RecordLabel { get; set; }

		/// <summary>The owning user ID.</summary>
		public virtual long OwnerID { get; set; }

		/// <summary>The owning user.</summary>
		public virtual MusicUser Owner { get; set; }

		/// <summary>The current state ID.</summary>
		public virtual long StateID { get; set; }

		/// <inheritdoc/>
		public virtual State State { get; set; }

		/// <inheritdoc/>
		public virtual int ChangeStamp { get; set; }

		/// <inheritdoc/>
		public virtual DateTime? LastStateChangeDate { get; set; }

		/// <inheritdoc/>
		public virtual DateTime? LastStateGroupChangeDate { get; set; }

		/// <summary>Tracks in the album.</summary>
		public virtual ICollection<Track> Tracks
		{
			get => tracks ?? (tracks = new ObservableHashSet<Track>());
			set => tracks = value;
		}

		/// <inheritdoc/>
		public virtual ICollection<AlbumStateTransition> StateTransitions
		{
			get => stateTransitions ?? (stateTransitions = new ObservableHashSet<AlbumStateTransition>());
			set => stateTransitions = value;
		}

		/// <inheritdoc/>
		long ISegregatedEntity.SegregationID => this.RecordLabelID;

		/// <inheritdoc/>
		RecordLabel ISegregatedEntity<MusicUser, RecordLabel>.Segregation => this.RecordLabel;

		/// <inheritdoc/>
		public bool IsOwnedBy(MusicUser user) => user != null && user.ID == this.OwnerID;

		/// <inheritdoc/>
		public object GetBackingDomainEntity() => this;
	}
}
