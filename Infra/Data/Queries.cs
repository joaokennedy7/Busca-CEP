namespace CEP.AddressInfra.Data
{
   public class Queries
    {
        public static string GetCep()
        {
            //return $"SELECT * FROM public.\"dbo.endereco\" WHERE cep = @cep";
            return $@"SELECT * FROM dbo.endereco WHERE cep = @cep";
        }

        public static string PostAddress()
        {
            //return $"INSERT INTO public.\"dbo.endereco\" (cep, logradouro, complemento, bairro, localidade, uf, ibge, gia, ddd, siafi) VALUES (@cep, @logradouro, @complemento, @bairro, @localidade, @uf, @ibge, @gia, @ddd, @siafi)";
            return $@"INSERT INTO dbo.endereco (cep, logradouro, complemento, bairro, localidade, uf, ibge, gia, ddd, siafi)
                    VALUES (@cep, @logradouro, @complemento, @bairro, @localidade, @uf,
                            @ibge, @gia, @ddd, @siafi)";
        }
    }
}
