using System;
namespace InstantLista_ClassLibrary
{
    /// <summary>
    ///     ToDoItem Api Model
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
      
        /// <summary>
        ///     Title of the To-Do-Item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Email
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// icon
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// user name
        /// </summary>
        public string UserName { get; set; }
    }
}

