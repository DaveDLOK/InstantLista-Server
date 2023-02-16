using System;
namespace InstantLista_ClassLibrary
{
    public class Membership
    {
        /// <summary>
        ///     Category which the To-Do-Item belongs to
        /// </summary>
        /// <summary>
        ///     User name
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///     User email
        /// </summary>
        public byte[] Salt { get; set; }
        public byte[] Password { get; set; }

        public DateTimeOffset LastLogin { get; set; }
    }
}

