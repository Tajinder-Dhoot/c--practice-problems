using CookiesCookbookAppRefactored.DataAccess;
using CookiesCookbookAppRefactored.FileAccess;
using CookiesCookbookAppRefactored.Recipes;
using CookiesCookbookAppRefactored.Recipes.Ingredients;
using CookiesCookbookAppRefactored.UserInteraction;
using CookiesCookbookAppRefactored.App;

const FileFormat Format = FileFormat.Txt;
const string FileName = "recipes";
var fileMetaData = new FileMetaData(FileName, Format);
IStringsRepository stringsRepository = Format == FileFormat.Json ? new StringsJsonRepository() : new StringsTextualRepository();
var ingredientsRegister = new IngredientsRegister();
var cookiesRecipesApp = new CookiesRecipeApp(
    new RecipesRepository(stringsRepository, ingredientsRegister),
    new RecipesConsoleUserInteraction(ingredientsRegister)
);

cookiesRecipesApp.Run(fileMetaData.ToPath());
