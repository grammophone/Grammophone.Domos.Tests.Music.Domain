using System;
using Grammophone.Domos.Domain;
using Grammophone.Domos.Domain.Workflow;

namespace Grammophone.Domos.Tests.Music.Domain
{
	/// <summary>
	/// Album workflow transition.
	/// </summary>
	[Serializable]
	public class AlbumStateTransition : StateTransition<MusicUser>
	{
		/// <summary>The album ID.</summary>
		public virtual long AlbumID { get; set; }

		/// <summary>The album.</summary>
		public virtual Album Album { get; set; }

		/// <inheritdoc/>
		public override void BindToStateful(object stateful)
		{
			if (!(stateful is Album album)) throw new DomainException("The stateful object is not an album.");

			this.Album = album;
			this.AlbumID = album.ID;
		}
	}
}
