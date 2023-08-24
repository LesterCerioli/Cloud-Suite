
using CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Core.Context
{
    public class CloudSuiteDbContext : DbContext 
    {
        public CloudSuiteDbContext(DbContextOptions options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
         
        public DbSet<Address> Addresses { get; set; }

        public DbSet<AppSetting> AppSettings { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Company> Companys { get; set; }    

        public DbSet<Country> Countries { get; set; }

        // public DbSet<Customer> Customers { get; set; }

        // public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<District> Districts { get; set; } 

        public DbSet<Entidade> Entidades { get; set; }

        public DbSet<EntidadeTipo> EntidadeTipos { get; set; }

        public DbSet<Media> Medias { get; set; }

        public DbSet<RoboEmail> roboEmails { get; set; }

        public DbSet<Role> Roles { get; set; }  

        public DbSet<State> States { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        
        public DbSet<Widget> Widgets { get; set; }

        public DbSet<WidgetInstance> WidgetInstances { get; set; }

        public DbSet<WidgetZone> WidgetZones { get; set; }

        //public DbSet<TipoCalculoCofins> TiposCalculosCofins { get; set; }

        //public DbSet<TipoCalculoIPI> TiposCalculosIPI { get; set; }

        //public DbSet<TipoCalculoPIS> TiposCalculosPIS { get; set; }

        //public DbSet<Icms> Icms { get; set; }

        //public DbSet<Cancelamento> Cancelamentos { get; set; }

        //public DbSet<CartaCorrecao> CartasCorrecoes { get; set; }

        //public DbSet<Download> Downloads { get; set; }

        //public DbSet<DownloadEvento> DownloadsEventos { get; set; }

        //public DbSet<DownloadInutilizacao> DownloadsInutilizacoes { get; set; }

        //public DbSet<Inutilizacao> Inutilizacoes { get; set; }

        //public DbSet<AccessKeyNFe> AccessKeysNFe { get; set; }

        //public DbSet<Bill> Bills { get; set; }

        //public DbSet<TipoEmissaoNF> TiposEmissoesNF { get; set; }

        //public DbSet<TipoEmissaoNFeEx> TiposEmissoesNFeEX { get; set; }

        //public DbSet<TipoEmissaoNFeEx> TiposEmissoesNFeEX { get; set; }

        //public DbSet<TipoFinalidade> TiposFinalidades { get; set; }

        //public DbSet<TipoFormatoImpressaoDanfe> TiposFormatosImpressoesDanfe { get; set; }

        //public DbSet<TipoIdentificadorLocalDestinoOperacao> TiposIdentificadoresLocaisDestinosOperacoes { get; set; }

        //public DbSet<TipoIndicadorPresencaComprador> TiposIndicadoresPresencaCompradores { get; set; }

        //public DbSet<TipoIntermedioImportacao> TiposIntermediosImportacoes { get; set; }

        //public DbSet<TipoModalidadeDocumentoFiscal> TiposModalidadesDocumentosFiscais { get; set; }

        //public DbSet<TipoModalidadeDocumentoFiscalEx> TiposModalidadesDocumentosFiscaisEx { get; set; }

        //public DbSet<TipoModalidadeFrete> TiposModalidadesFrete { get; set; }

        //public DbSet<TipoNotaFiscal> TiposNotasFiscais { get; set; }

        //public DbSet<TipoPagamento> TiposPagamentos { get; set; }

        //public DbSet<TipoProcessoEmissaoNFe> TiposProcessosEmissoesNFe { get; set; }

        //public DbSet<TipoProdutoEspecifico> TiposProdutosEspecificos { get; set; }

        //public DbSet<TiposBasicos> TiposBasicos { get; set; }

        //public DbSet<CofinsTaxStatus> CofinsTaxesStatus { get; set; }

        //public DbSet<IcmsTaxStatus> IcmsTaxesStatus { get; set; }

        //public DbSet<IpiTaxStatus> IpiTaxesStatus { get; set; }

        //public DbSet<PisTaxStatus> PisTaxesStatus { get; set; }

        //public DbSet<PisTaxStatus> PisTaxesStatus { get; set; }

        //public DbSet<SsqnTaxStatus> SsqnTaxesStatus { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<EventArgs>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //modelBuilder.ApplyConfiguration(new AddressMap());
            //modelBuilder.ApplyConfiguration(new AppSettingMap());
            //modelBuilder.ApplyConfiguration(new CityMap());
            //modelBuilder.ApplyConfiguration(new CompanyMap());
            //modelBuilder.ApplyConfiguration(new CountryMap());
            //modelBuilder.ApplyConfiguration(new CustomerMap());
            //modelBuilder.ApplyConfiguration(new CustomerGroupMap());
            //modelBuilder.ApplyConfiguration(new DistrictMap());
            //modelBuilder.ApplyConfiguration(new EntidadeMap());
            //modelBuilder.ApplyConfiguration(new EntidadeTipoMap());
            //modelBuilder.ApplyConfiguration(new MediaMap());
            //modelBuilder.ApplyConfiguration(new RoboEmailMap());
            //modelBuilder.ApplyConfiguration(new RoleMap());
            //modelBuilder.ApplyConfiguration(new StateMap());
            //modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new UserRoleMap());
            //modelBuilder.ApplyConfiguration(new VendorMap());
            //modelBuilder.ApplyConfiguration(new WidgetMap());
            //modelBuilder.ApplyConfiguration(new WidgetInstanceMap());
            //modelBuilder.ApplyConfiguration(new WidgetZoneMap());

            //modelBuilder.ApplyConfiguration(new TipoCalculoCofinsMap());
            //modelBuilder.ApplyConfiguration(new TipoCalculoIPIMap());
            //modelBuilder.ApplyConfiguration(new TipoCalculoPISMap());
            //modelBuilder.ApplyConfiguration(new IcmsMap());
            //modelBuilder.ApplyConfiguration(new CancelamentoMap());
            //modelBuilder.ApplyConfiguration(new CartaCorrecaoMap());
            //modelBuilder.ApplyConfiguration(new DownloadMap());
            //modelBuilder.ApplyConfiguration(new DownloadEventoMap());
            //modelBuilder.ApplyConfiguration(new DownloadInutilizacaoMap());
            //modelBuilder.ApplyConfiguration(new InutilizacaoMap());
            //modelBuilder.ApplyConfiguration(new AccessKeyNFeMap());
            //modelBuilder.ApplyConfiguration(new BillMap());
            //modelBuilder.ApplyConfiguration(new TipoEmissaoNFMap());
            //modelBuilder.ApplyConfiguration(new TipoEmissaoNFeExMap());
            //modelBuilder.ApplyConfiguration(new TipoFinalidadeMap());
            //modelBuilder.ApplyConfiguration(new TipoFormatoImpressaoDanfeMap());
            //modelBuilder.ApplyConfiguration(new TipoIdentificadorLocalDestinoOperacaoMap());
            //modelBuilder.ApplyConfiguration(new TipoIndicadorPresencaCompradorMap());
            //modelBuilder.ApplyConfiguration(new TipoIntermedioImportacaoMap());
            //modelBuilder.ApplyConfiguration(new TipoModalidadeDocumentoFiscalMap());
            //modelBuilder.ApplyConfiguration(new TipoModalidadeDocumentoFiscalExMap());
            //modelBuilder.ApplyConfiguration(new TipoModalidadeFreteMap());
            //modelBuilder.ApplyConfiguration(new TipoNotaFiscalMap());
            //modelBuilder.ApplyConfiguration(new TipoPagamentoMap());
            //modelBuilder.ApplyConfiguration(new TipoProcessoEmissaoNFeMap());
            //modelBuilder.ApplyConfiguration(new TipoProdutoEspecificoMap());
            //modelBuilder.ApplyConfiguration(new TiposBasicosMap());
            //modelBuilder.ApplyConfiguration(new CofinsTaxStatusMap());
            //modelBuilder.ApplyConfiguration(new IcmsTaxStatusMap());
            //modelBuilder.ApplyConfiguration(new IpiTaxStatusMap());
            //modelBuilder.ApplyConfiguration(new PisTaxStatusMap());
            //modelBuilder.ApplyConfiguration(new SsqnTaxStatusMap());



            modelBuilder.Entity<Address>(c =>
            {
                c.ToTable("Addresses");
            });

            modelBuilder.Entity<AppSetting>(c =>
            {
                c.ToTable("AppSettings");
            });

            modelBuilder.Entity<City>(c =>
            {
                c.ToTable("Cities");
            });

            modelBuilder.Entity<Company>(c =>
            {
                c.ToTable("Companys");
            });

            modelBuilder.Entity<Country>(c =>
            {
                c.ToTable("Contries");
            });

            // modelBuilder.Entity<Customer>(c =>
            // {
            //     c.ToTable("Customers");
            // });

            // modelBuilder.Entity<CustomerGroup>(c =>
            // {
            //     c.ToTable("CustomerGroups");
            // });

            // modelBuilder.Entity<CustomerGroupUser>(c =>
            // {
            //     c.ToTable("CustomerGroupUsers");
            // });

            modelBuilder.Entity<District>(c =>
            {
                c.ToTable("Districts");
            });

            modelBuilder.Entity<Entidade>(c =>
            {
                c.ToTable ("Entidades");
            });

            modelBuilder.Entity<EntidadeTipo>(c =>
            {
                c.ToTable("EntidadeTipos");
            });
            
            modelBuilder.Entity<Media>(c =>
            {
                c.ToTable("Medias");
            });

            modelBuilder.Entity<RoboEmail>(c =>
            {
                c.ToTable("RoboEmails");
            });

            modelBuilder.Entity<Role>(c =>
            {
                c.ToTable("Roles");
            });

            modelBuilder.Entity<State>(c =>
            {
                c.ToTable("States");
            });

            modelBuilder.Entity<User>(c =>
            {
                c.ToTable("Users");
            });

            modelBuilder.Entity<UserRole>(c =>
            {
                c.ToTable("UserRoles");
            });

            modelBuilder.Entity<Vendor>(c =>
            {
                c.ToTable("Vendors");
            });

            modelBuilder.Entity<Widget>(c =>
            {
                c.ToTable("Widgets");
            });

            modelBuilder.Entity<WidgetInstance>(c =>
            {
                c.ToTable("WidgetInstances");
            });

            modelBuilder.Entity<WidgetZone>(c =>
            {
                c.ToTable("WidgetZones");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
