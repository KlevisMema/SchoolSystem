namespace SchoolSystem.API.ControllerRespose
{
    public class CustomMesageResponse
    {
        public bool Exists { get; set; }
        public string CustomMessage { get; set; }

        public CustomMesageResponse(bool exists, string customMessage)
        {
            Exists = exists;
            CustomMessage = customMessage;
        }

        public static CustomMesageResponse Succsess()
        {
            return new CustomMesageResponse(true, string.Empty);
        }

        public static CustomMesageResponse NotFound(bool Exists ,string customMessage)
        {
            return new CustomMesageResponse(Exists, customMessage);
        }
    }
}