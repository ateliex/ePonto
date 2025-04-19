using ePonto.Drivers;

namespace ePonto.StepDefinitions
{
    [Binding]
    public class RegistroPontosStepDefinitions
    {
        private readonly RegistroPontosPageDriver _driver;

        public RegistroPontosStepDefinitions(RegistroPontosPageDriver driver)
        {
            _driver = driver;
        }

        [Given("que o trabalhador {string} está autenticado")]
        public void GivenQueOTrabalhadorEstaAutenticado(string trabalhador)
        {
            //throw new PendingStepException();
        }

        [When("o trabalhador {string} marcar o ponto às {string}")]
        public void WhenOTrabalhadorMarcarOPontoAs(string trabalhador, DateTime dataHora)
        {
            _driver.MarcarPonto();
        }

        [When("ele marcar o ponto às {string}")]
        public void WhenEleMarcarOPontoAs(string p0)
        {
            throw new PendingStepException();
        }

        [Then("um ponto deverá ser registrado para o trabalhador {string} às {string}")]
        public void ThenUmPontoDeveraSerRegistradoParaOTrabalhadorAs(string trabalhador, DateTime dataHora)
        {
            throw new PendingStepException();
        }

        [Then("um ponto deverá ser registrado para ele como esperado")]
        public void ThenUmPontoDeveraSerRegistradoParaEleComoEsperado()
        {
            throw new PendingStepException();
        }
    }
}
