namespace SchoolSystem.API.ControllerRespose
{
    /// <summary>
    /// Custom resposne message class
    /// </summary>
    public class CustomMesageResponse
    {
        /// <summary>
        ///     Boolean property which will take a value depending of a another function functionality
        /// </summary>
        public bool Exists { get; set; }
        /// <summary>
        ///     String property which will take a custom value depending of another function functionality
        /// </summary>
        public string CustomMessage { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="exists"></param>
        /// <param name="customMessage"></param>
        public CustomMesageResponse
        (
            bool exists,
            string customMessage
        )
        {
            Exists = exists;
            CustomMessage = customMessage;
        }

        /// <summary>
        /// Method that returns true indicating that the process was succsessfull and a custom message 
        /// </summary>
        public static CustomMesageResponse Succsess
        (
        )
        {
            return new CustomMesageResponse(true, string.Empty);
        }

        /// <summary>
        /// Method that returns false indicating that the process falied and a custom message 
        /// </summary>
        public static CustomMesageResponse NotFound
        (
            bool Exists,
            string customMessage
        )
        {
            return new CustomMesageResponse(Exists, customMessage);
        }
    }
}