using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace PubQuizBuster.ActivityCreator;

public sealed partial class GeographyActivityControl : UserControl
{
    public GeographyActivityControl()
    {
        InitializeComponent();
    }

    private async void btnGetCountries_Click(object sender, EventArgs e)
    {
        await getCountriesAsync();
    }

    private async Task getCountriesAsync()
    {
        const string url = "query.wikidata.org";
    }

    string sovereignState_sparql = "Q3624078";
    string city_sparql = "Q515";
    string country_sparql = "P17";
    string instanceOf_sparql = "P31";
    string population_sparql = "P1082";
    string landmass_sparql = "P2046";

    public string continent = "any";
    private void _continentCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
        continent = _continentCombo.SelectedIndex.ToString();
    }

    public string category = "country";
    private void _categoryCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
        category = _categoryCombo.SelectedIndex.ToString();
    }

    public Boolean correctAnswer = false;
    private void _correctAnswerCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        correctAnswer = _correctAnswerCheckBox.Checked;
    }

    public string populationMax = "10000000000";
    private void _maxPopulationTextBox_TextChanged(object sender, EventArgs e)
    {
        populationMax = _maxPopulationLabel.Text;
    }

    public string populationMin = "0";
    private void _minPopulationTextBox_TextChanged(object sender, EventArgs e)
    {
        populationMin = _minPopulationLabel.Text;
    }

    public string landmassMax = "150000000";
    private void _maxLandmassTextBox_TextChanged(object sender, EventArgs e)
    {
        landmassMax = _maxLandmassLabel.Text;
    }

    public string landmassMin = "0";
    private void _minLandmassTextBox_TextChanged(object sender, EventArgs e)
    {
        landmassMin = _minLandmassLabel.Text;
    }

    public string countryFilter;
    string[,] currentAnswers = new string[8, 2];

    private void buildSparqlQuery()
    {
        var query = @"
        
        ";
    }
}
