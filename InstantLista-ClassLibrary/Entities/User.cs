using System;
namespace InstantLista_ClassLibrary
{
    /// <summary>
    ///     ToDoItem Api Model
    /// </summary>
    public class User
    {
        /// <summary>
        /// Email
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? UserToken { get; set; }
        public string? Icon { get; set; }

    }
}

