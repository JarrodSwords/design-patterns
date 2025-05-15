using Dapper;
using Microsoft.Data.SqlClient;

namespace DesignPatterns.Sandbox;

public interface ISldRepository
{
    AdministrationStatusFieldingCount GetRawFieldingCount(IEnumerable<long> surveyIds);
}

public class SldRepository
{
    public const string RawFieldingCountQuery = """
                                                SELECT COUNT (DISTINCT IT_SURVEY_ID) AS Quantity, WaveTypeString
                                                FROM (SELECT sdl.IT_SURVEY_ID,
                                                CASE userid.slong(survey, quest_id)
                                                When '1' Then 'M'
                                                When '2' Then 'E'
                                                When '3' Then 'P'
                                                END AS WaveTypeString
                                                FROM userid.surv_data_later sdl, userid.quest_defn b
                                                WHERE sdl.IT_SURVEY_ID IN @surveyIds
                                                AND quest_var_name = 'DISTRIB'
                                                UNION ALL
                                                SELECT sd.IT_SURVEY_ID,
                                                CASE userid.slong(survey, quest_id)
                                                When '1' Then 'M'
                                                When '2' Then 'E'
                                                When '3' Then 'P'
                                                END AS WaveTypeString
                                                FROM userid.surv_data sd, userid.quest_defn b
                                                WHERE sd.IT_SURVEY_ID IN @surveyIds
                                                AND quest_var_name = 'DISTRIB')
                                                WHERE WaveTypeString IS NOT NULL
                                                GROUP BY WaveTypeString
                                                WITH UR
                                                """;

    public AdministrationStatusFieldingCount GetRawFieldingCount(IEnumerable<long> surveyIds)
    {
        using var conn = new SqlConnection();
        conn.Open();

        var waveTypeQuantities = conn.Query<WaveTypeQuantity>(RawFieldingCountQuery, new { surveyIds });

        var result = new AdministrationStatusFieldingCount();

        foreach (var wtq in waveTypeQuantities)
            result += wtq;

        return result;
    }
}
