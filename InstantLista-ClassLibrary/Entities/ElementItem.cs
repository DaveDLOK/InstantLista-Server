using System;
namespace InstantLista_ClassLibrary
{
    /// <summary>
    ///     ToDoItem Api Model
    /// </summary>
    public class ElementItem
    {
        /// <summary>
        /// Email
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? DisplayOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ListId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? UserId { get; set; }

    }
}

