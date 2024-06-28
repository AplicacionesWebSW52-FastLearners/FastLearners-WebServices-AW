using Microsoft.EntityFrameworkCore;

namespace FastLearnersPlatform.API.Users.Shared.Extensions;

public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(ModelBuilderExtensions.ToSnakeCase(entity.GetTableName()));

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(ModelBuilderExtensions.ToSnakeCase(property.GetColumnBaseName()));
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(ModelBuilderExtensions.ToSnakeCase(key.GetName()));
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(ModelBuilderExtensions.ToSnakeCase(foreignKey.GetConstraintName()));
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(ModelBuilderExtensions.ToSnakeCase(index.GetDatabaseName()));
            }
        }
    }

    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) { return input; }

        var startUnderscores = System.Text.RegularExpressions.Regex.Match(input, @"^_+");
        return startUnderscores + string.Concat(input
                .SkipWhile(c => c == '_')
                .Select((c, i) => i > 0 && char.IsUpper(c) ? "_" + c : c.ToString()))
            .ToLower();
    }
}