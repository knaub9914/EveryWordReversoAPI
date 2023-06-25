using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReversoAPI;
using ReversoContextGetExample.Models;

namespace ReversoContextGetExample.Controllers;

[ApiController]
[Route("[controller]")]
public class GetReversoContextExamples : ControllerBase
{
    private readonly ILogger<GetReversoContextExamples> _logger;

    public GetReversoContextExamples(ILogger<GetReversoContextExamples> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetContextExamples")]
    public async Task<List<ReversoContextExample>> GetContextExamplesBySourceLanguage(
        string Word, string SourceLanguage, string TargetLanguage) {

        var reverso = new ReversoClient();
        ContextData context = new ContextData();
        List<ReversoContextExample> exampleSentences = new List<ReversoContextExample>();
        Language sourceLanguage = Enum.Parse<ReversoAPI.Language>(SourceLanguage);
        Language targetLanguage = Enum.Parse<ReversoAPI.Language>(TargetLanguage);
        try
        {
            context = await reverso.Context.GetAsync(Word, sourceLanguage, targetLanguage);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        var examples = context.Examples.ToList();

        for (int i = 0; i < examples.Count(); i++)
        {
            exampleSentences.Add(new ReversoContextExample { Content = examples[i].Source.Text.ToString(),
                Id = Guid.NewGuid(),SourceLanguage = SourceLanguage });
        }
        return exampleSentences;
    }
}

