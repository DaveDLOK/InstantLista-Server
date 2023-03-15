using System;
namespace InstantLista_ClassLibrary
{
    /// <summary>
    ///     ToDoItem Api Model
    /// </summary>
    public class NewsDto
    {
        public int Id { get; set; }
      
        /// <summary>
        ///     Title of the To-Do-Item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  Email
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// icon
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// user name
        /// </summary>
        public string Url { get; set; }
    }
}

