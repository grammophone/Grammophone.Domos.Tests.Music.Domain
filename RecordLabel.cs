using System;
using Grammophone.Domos.Domain;

namespace Grammophone.Domos.Tests.Music.Domain
{
	/// <summary>
	/// Data segregation representing a record label.
	/// </summary>
	[Serializable]
	public class RecordLabel : Segregation<MusicUser>
	{
		/// <summary>
		/// The label name.
		/// </summary>
		public virtual string Name { get; set; }
	}
}
