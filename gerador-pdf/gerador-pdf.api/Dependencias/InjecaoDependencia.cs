using gerador_pdf.api.Service;

namespace gerador_pdf.api.Dependencias
{
    public static class InjecaoDependencia
    {
        public static void Dependencia(this IServiceCollection services)
        {
            services.AddTransient<IGeradorPdfServices, GeradorPdfService>();
        }
    }
}
