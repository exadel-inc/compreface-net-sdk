namespace Exadel.Compreface.Builder
{
    public class Director
    {
        private ICompreFaceBuilder _compreFaceBuilder;
        public ICompreFaceBuilder Builder
        {
            set { _compreFaceBuilder = value; }
        }
        public void BuildFullServices()
        {
            this._compreFaceBuilder.BuildFaceDetection();
            this._compreFaceBuilder.BuildVerification();
            this._compreFaceBuilder.BuildRecognition();
        }
    }
}
