using System;
namespace InstantLista_ClassLibrary
{
    /// <summary>
    ///     ToDoItem Api Model
    /// </summary>
    public class News
    {
        /// <summary>
        ///     Category which the To-Do-Item belongs to
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///     Title of the To-Do-Item
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        ///  Email
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        ///  UserNumber
        /// </summary>
        public string? Image { get; set; }
        /// <summary>
        /// icon
        /// </summary>
        public string? Url { get; set; }
    }
}

