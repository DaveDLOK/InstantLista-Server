namespace InstantLista_ClassLibrary.DataTransferObjects
{
    /// <summary>
    ///     ToDoItem Api Model
    /// </summary>
    public class TokenJWTDto
    {
        /// <summary>
        /// IdToken
        /// </summary>
        public string IdToken { get; set; }
        /// <summary>
        /// ExpiresIn
        /// </summary>
        public string ExpiresIn { get; set; }
        /// <summary>
        /// UserNumber
        /// </summary>
        public string UserNumber { get; set; }
    }
}

