using System;
namespace InstantLista_ClassLibrary
{
    /// <summary>
    ///     ToDoItem Api Model
    /// </summary>
    public class Feeditem
    {
        /// <summary>
        /// Email
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public ElementItem ElementItem { get; set; }
        public User UserToShare { get; set; }
    }
}

