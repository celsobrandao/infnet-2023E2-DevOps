using DockerInfnetDevOpsSample.Controllers;

namespace TestApi
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void DeveFazerGetComSucesso()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get();

            Assert.True(result.Any());
        }

        [Fact]
        public void DeveFazerGetComFalha()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get();

            Assert.False(!result.Any());
        }
    }
}