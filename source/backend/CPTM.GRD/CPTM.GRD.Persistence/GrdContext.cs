using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Acoes.Children;
using CPTM.GRD.Domain.Logging;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Proposicoes.Children;
using CPTM.GRD.Domain.Reunioes;
using CPTM.GRD.Domain.Reunioes.Children;
using CPTM.GRD.Persistence.ConfigurationTables;
using CPTM.GRD.Persistence.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace CPTM.GRD.Persistence
{
    public partial class GrdContext : DbContext
    {
        public GrdContext()
        {
        }

        public GrdContext(DbContextOptions<GrdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;

        public virtual DbSet<Acao> Acoes { get; set; } = null!;
        public virtual DbSet<Andamento> Andamentos { get; set; } = null!;

        public virtual DbSet<Proposicao> Proposicoes { get; set; } = null!;
        public virtual DbSet<Resolucao> Resolucoes { get; set; } = null!;
        public virtual DbSet<Voto> Votos { get; set; } = null!;

        public virtual DbSet<Reuniao> Reunioes { get; set; } = null!;
        public virtual DbSet<Participante> Participantes { get; set; } = null!;

        public virtual DbSet<LogAcao> LogsAcao { get; set; } = null!;
        public virtual DbSet<LogProposicao> LogsProposicao { get; set; } = null!;
        public virtual DbSet<LogReuniao> LogReuniao { get; set; } = null!;

        public virtual DbSet<GrdConfiguracao> GrdConfiguracoes { get; set; } = null!;
        public virtual DbSet<GrdUsuarioPreferencia> GrdUsuarioPreferencias { get; set; } = null!;
        public virtual DbSet<GrdVwCargo> GrdVwCargos { get; set; } = null!;
        public virtual DbSet<GrdVwCasisGrupo> GrdVwCasisGrupos { get; set; } = null!;
        public virtual DbSet<GrdVwCasisGrupoUsuario> GrdVwCasisGrupoUsuarios { get; set; } = null!;
        public virtual DbSet<GrdVwEstruturaOrg> GrdVwEstruturasOrg { get; set; } = null!;
        public virtual DbSet<GrdVwFuncao> GrdVwFuncoes { get; set; } = null!;
        public virtual DbSet<GrdVwUsuario> GrdVwUsuarios { get; set; } = null!;
        public virtual DbSet<GrdVwUsuarioFoto> GrdVwUsuarioFotos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GRD");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GrdContext).Assembly);

            modelBuilder.Entity<User>().ToTable("GRD_USERS");
            modelBuilder.Entity<User>().Property(u => u.UsernameAd).HasMaxLength(250);
            modelBuilder.Entity<User>()
                .HasMany<Group>(u => u.AreasAcesso)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Group");
            modelBuilder.Entity<User>().Navigation(u => u.AreasAcesso).AutoInclude();

            modelBuilder.Entity<Group>().ToTable("GRD_GROUPS");
            modelBuilder.Entity<Group>().Property(g => g.Sigla).HasMaxLength(250);
            modelBuilder.Entity<Group>().Property(g => g.SiglaDiretoria).HasMaxLength(250);
            modelBuilder.Entity<Group>().Property(g => g.SiglaGerencia).HasMaxLength(250);
            modelBuilder.Entity<Group>()
                .HasOne<User>(g => g.Relator)
                .WithOne()
                .HasForeignKey("User")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groups_User");
            modelBuilder.Entity<Group>().Navigation(g => g.Relator).AutoInclude();

            modelBuilder.Entity<Acao>().ToTable("GRD_ACOES");
            modelBuilder.Entity<Acao>()
                .HasMany<Andamento>(a => a.Andamentos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Acoes_Andamento");
            modelBuilder.Entity<Acao>().Navigation(a => a.Andamentos).AutoInclude();
            modelBuilder.Entity<Acao>()
                .HasOne<Group>(a => a.DiretoriaRes)
                .WithOne()
                .HasForeignKey("Group")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acoes_Group");
            modelBuilder.Entity<Acao>().Navigation(a => a.DiretoriaRes).AutoInclude();
            //modelBuilder.Entity<Acao>().Navigation(a => a.Logs).AutoInclude();
            modelBuilder.Entity<Andamento>().ToTable("GRD_ANDAMENTOS");
            modelBuilder.Entity<Andamento>()
                .HasOne<User>(an => an.User)
                .WithOne()
                .HasForeignKey("User")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Andamentos_Users");
            modelBuilder.Entity<Andamento>().Navigation(an => an.User).AutoInclude();
            modelBuilder.Entity<Andamento>()
                .Property(p => p.AnexosFilePaths)
                .HasConversion(new ValueConverter<ICollection<string>, string>(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ICollection<string>>(v) ?? new List<string>()));

            modelBuilder.Entity<Proposicao>().ToTable("GRD_PROPOSICOES");
            modelBuilder.Entity<Proposicao>()
                .HasMany<Voto>(p => p.VotosRd)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Proposicoes_Voto");
            modelBuilder.Entity<Proposicao>().Navigation(p => p.VotosRd).AutoInclude();
            modelBuilder.Entity<Proposicao>()
                .HasOne<Group>(p => p.AreaSolicitante)
                .WithOne()
                .HasForeignKey("Group")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposicoes_Group");
            modelBuilder.Entity<Proposicao>().Navigation(p => p.AreaSolicitante).AutoInclude();
            modelBuilder.Entity<Proposicao>()
                .HasOne<User>(p => p.Criador)
                .WithOne()
                .HasForeignKey("User")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposicoes_User");
            modelBuilder.Entity<Proposicao>().Navigation(p => p.Criador).AutoInclude();
            //modelBuilder.Entity<Proposicao>().HasOne<Resolucao>(p => p.Resolucao);
            //modelBuilder.Entity<Proposicao>().Navigation(p => p.Resolucao).AutoInclude();
            //modelBuilder.Entity<Proposicao>().Navigation(p => p.Logs).AutoInclude();
            modelBuilder.Entity<Proposicao>()
                .Property(p => p.OutrosFilePath)
                .HasConversion(new ValueConverter<ICollection<string>, string>(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ICollection<string>>(v) ?? new List<string>()));
            modelBuilder.Entity<Resolucao>().ToTable("GRD_RESOLUCOES");
            modelBuilder.Entity<Voto>().ToTable("GRD_VOTOS");
            modelBuilder.Entity<Voto>()
                .HasOne<Participante>(v => v.Participante)
                .WithOne()
                .HasForeignKey("Participante")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Votos_Participante");
            modelBuilder.Entity<Voto>().Navigation(v => v.Participante).AutoInclude();

            modelBuilder.Entity<Reuniao>().ToTable("GRD_REUNIOES");
            modelBuilder.Entity<Reuniao>()
                .HasMany<Proposicao>(r => r.Proposicoes)
                .WithOne(p => p.Reuniao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reunioes_Proposicao");
            modelBuilder.Entity<Reuniao>().Navigation(r => r.Proposicoes).AutoInclude();
            modelBuilder.Entity<Reuniao>()
                .HasMany<Proposicao>(r => r.ProposicoesPrevia)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reunioes_ProposicaoPrev");
            modelBuilder.Entity<Reuniao>().Navigation(r => r.ProposicoesPrevia).AutoInclude();
            modelBuilder.Entity<Reuniao>()
                .HasMany<Participante>(r => r.Participantes)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Reunioes_Participante");
            modelBuilder.Entity<Reuniao>().Navigation(r => r.Participantes).AutoInclude();
            modelBuilder.Entity<Reuniao>()
                .HasMany<Participante>(r => r.ParticipantesPrevia)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Reunioes_ParticipantePrev");
            modelBuilder.Entity<Reuniao>().Navigation(r => r.ParticipantesPrevia).AutoInclude();
            modelBuilder.Entity<Reuniao>()
                .HasMany<Acao>(r => r.Acoes)
                .WithMany(a => a.Reunioes)
                .UsingEntity(j => j.ToTable("ReuniaoAcao"));
            modelBuilder.Entity<Reuniao>().Navigation(r => r.Acoes).AutoInclude();
            //modelBuilder.Entity<Reuniao>().Navigation(r => r.Logs).AutoInclude();
            modelBuilder.Entity<Participante>().ToTable("GRD_PARTICIPANTES");
            modelBuilder.Entity<Participante>()
                .HasOne<User>(p => p.User)
                .WithOne()
                .HasForeignKey("User")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participantes_User");
            modelBuilder.Entity<Participante>().Navigation(p => p.User).AutoInclude();
            modelBuilder.Entity<Participante>()
                .HasOne<Group>(p => p.DiretoriaArea)
                .WithOne()
                .HasForeignKey("Group")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participantes_Group");
            modelBuilder.Entity<Participante>().Navigation(p => p.DiretoriaArea).AutoInclude();

            modelBuilder.Entity<LogAcao>().ToTable("GRD_LOGS_ACAO");
            modelBuilder.Entity<LogAcao>()
                .HasOne<Acao>()
                .WithMany(a => a.Logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogsAcao_Acao");
            modelBuilder.Entity<LogAcao>()
                .HasOne<User>(l => l.UsuarioResp)
                .WithOne()
                .HasForeignKey("User")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogsAcao_User");
            modelBuilder.Entity<LogProposicao>().ToTable("GRD_LOGS_PROPOSICAO");
            modelBuilder.Entity<LogProposicao>()
                .HasOne<Proposicao>()
                .WithMany(a => a.Logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogsProposicao_Proposicao");
            modelBuilder.Entity<LogProposicao>()
                .HasOne<User>(l => l.UsuarioResp)
                .WithOne()
                .HasForeignKey("User")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogsProposicao_User");
            modelBuilder.Entity<LogReuniao>().ToTable("GRD_LOGS_REUNIAO");
            modelBuilder.Entity<LogReuniao>()
                .HasOne<Reuniao>()
                .WithMany(a => a.Logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogsReuniao_Reuniao");
            modelBuilder.Entity<LogReuniao>()
                .HasOne<User>(l => l.UsuarioResp)
                .WithOne()
                .HasForeignKey("User")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogsReuniao_User");

            modelBuilder.Entity<GrdConfiguracao>(entity =>
            {
                entity.HasKey(e => e.Parametro)
                    .HasName("PK_CONFIGURACAO");

                entity.ToTable("GRD_CONFIGURACAO");

                entity.Property(e => e.Parametro)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PARAMETRO");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_ALTERACAO");

                entity.Property(e => e.DtCadastro)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_CADASTRO");

                entity.Property(e => e.IdCodusuarioAlteracao)
                    .HasPrecision(6)
                    .HasColumnName("ID_CODUSUARIO_ALTERACAO");

                entity.Property(e => e.IdCodusuarioCadastro)
                    .HasPrecision(6)
                    .HasColumnName("ID_CODUSUARIO_CADASTRO");

                entity.Property(e => e.TxDescricao)
                    .IsUnicode(false)
                    .HasColumnName("TX_DESCRICAO");

                entity.Property(e => e.Valor)
                    .IsUnicode(false)
                    .HasColumnName("VALOR");
            });

            modelBuilder.Entity<GrdUsuarioPreferencia>(entity =>
            {
                entity.HasKey(e => new { IdCodusuario = e.IdCodUsuario, e.TxCategoria })
                    .HasName("PK_USUARIO_PREFERENCIA");

                entity.ToTable("GRD_USUARIO_PREFERENCIA");

                entity.Property(e => e.IdCodUsuario)
                    .HasPrecision(8)
                    .HasColumnName("ID_CODUSUARIO");

                entity.Property(e => e.TxCategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_CATEGORIA");

                entity.Property(e => e.TxValor)
                    .HasColumnType("CLOB")
                    .HasColumnName("TX_VALOR");
            });

            modelBuilder.Entity<GrdVwCargo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GRD_VW_CARGO");

                entity.Property(e => e.FlAtivo)
                    .HasPrecision(1)
                    .HasColumnName("FL_ATIVO");

                entity.Property(e => e.IdCargo)
                    .HasPrecision(10)
                    .HasColumnName("ID_CARGO");

                entity.Property(e => e.TxCargo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_CARGO");
            });

            modelBuilder.Entity<GrdVwCasisGrupo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GRD_VW_CASIS_GRUPO");

                entity.Property(e => e.IdGrupo)
                    .HasPrecision(6)
                    .HasColumnName("ID_GRUPO");

                entity.Property(e => e.IdSistema)
                    .HasPrecision(6)
                    .HasColumnName("ID_SISTEMA");

                entity.Property(e => e.TxDescrGrupo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_DESCR_GRUPO");

                entity.Property(e => e.TxSigla)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TX_SIGLA");
            });

            modelBuilder.Entity<GrdVwCasisGrupoUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GRD_VW_CASIS_GRUPO_USUARIO");

                entity.Property(e => e.IdCodusuario)
                    .HasPrecision(8)
                    .HasColumnName("ID_CODUSUARIO");

                entity.Property(e => e.IdGrupo)
                    .HasPrecision(6)
                    .HasColumnName("ID_GRUPO");
            });

            modelBuilder.Entity<GrdVwEstruturaOrg>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GRD_VW_ESTRUTURA_ORG");

                entity.Property(e => e.CdCentroCusto)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CD_CENTRO_CUSTO");

                entity.Property(e => e.CdTipoEstrutura)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CD_TIPO_ESTRUTURA");

                entity.Property(e => e.DepSigla)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEP_SIGLA");

                entity.Property(e => e.DirSigla)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIR_SIGLA");

                entity.Property(e => e.FlAtivo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FL_ATIVO");

                entity.Property(e => e.GerSigla)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GER_SIGLA");

                entity.Property(e => e.GgSigla)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GG_SIGLA");

                entity.Property(e => e.IdEstrutura)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ID_ESTRUTURA");

                entity.Property(e => e.NrNivel)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NR_NIVEL");

                entity.Property(e => e.TxBairro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_BAIRRO");

                entity.Property(e => e.TxCidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_CIDADE");

                entity.Property(e => e.TxComplemento)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TX_COMPLEMENTO");

                entity.Property(e => e.TxEnderecoCompleto)
                    .HasMaxLength(211)
                    .IsUnicode(false)
                    .HasColumnName("TX_ENDERECO_COMPLETO");

                entity.Property(e => e.TxEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TX_ESTADO");

                entity.Property(e => e.TxLogradouro)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TX_LOGRADOURO");

                entity.Property(e => e.TxNome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_NOME");

                entity.Property(e => e.TxNomeReduzido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_NOME_REDUZIDO");

                entity.Property(e => e.TxNumero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TX_NUMERO");

                entity.Property(e => e.TxSigla)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TX_SIGLA");

                entity.Property(e => e.TxTipoEstrutura)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TX_TIPO_ESTRUTURA");
            });

            modelBuilder.Entity<GrdVwFuncao>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GRD_VW_FUNCAO");

                entity.Property(e => e.FlAtivo)
                    .HasPrecision(1)
                    .HasColumnName("FL_ATIVO");

                entity.Property(e => e.IdFuncao)
                    .HasPrecision(6)
                    .HasColumnName("ID_FUNCAO");

                entity.Property(e => e.TxFuncao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_FUNCAO");
            });

            modelBuilder.Entity<GrdVwUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GRD_VW_USUARIO");

                entity.Property(e => e.CdFuncionario)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CD_FUNCIONARIO");

                entity.Property(e => e.CdSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_SEXO")
                    .IsFixedLength();

                entity.Property(e => e.CdStatusEmpregado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CD_STATUS_EMPREGADO");

                entity.Property(e => e.CdTipoFuncionario)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CD_TIPO_FUNCIONARIO");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DtAdmissao)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_ADMISSAO");

                entity.Property(e => e.DtAtualizacao)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_ATUALIZACAO");

                entity.Property(e => e.DtDemissao)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_DEMISSAO");

                entity.Property(e => e.DtDesligamentoTerceiro)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_DESLIGAMENTO_TERCEIRO");

                entity.Property(e => e.DtExpiracao)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_EXPIRACAO");

                entity.Property(e => e.DtNascimento)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_NASCIMENTO");

                entity.Property(e => e.FlAtivo)
                    .HasPrecision(1)
                    .HasColumnName("FL_ATIVO");

                entity.Property(e => e.FlAtivoAd)
                    .HasPrecision(1)
                    .HasColumnName("FL_ATIVO_AD");

                entity.Property(e => e.FlAtvNrm)
                    .HasPrecision(1)
                    .HasColumnName("FL_ATV_NRM");

                entity.Property(e => e.FlEmpregado)
                    .HasPrecision(1)
                    .HasColumnName("FL_EMPREGADO");

                entity.Property(e => e.IdCargo)
                    .HasPrecision(10)
                    .HasColumnName("ID_CARGO");

                entity.Property(e => e.IdChefePonto)
                    .HasPrecision(6)
                    .HasColumnName("ID_CHEFE_PONTO");

                entity.Property(e => e.IdCodusuario)
                    .HasPrecision(6)
                    .HasColumnName("ID_CODUSUARIO");

                entity.Property(e => e.IdCodusuarioGestorAd)
                    .HasPrecision(6)
                    .HasColumnName("ID_CODUSUARIO_GESTOR_AD");

                entity.Property(e => e.IdFuncao)
                    .HasPrecision(6)
                    .HasColumnName("ID_FUNCAO");

                entity.Property(e => e.IdMix)
                    .HasPrecision(10)
                    .HasColumnName("ID_MIX");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA");

                entity.Property(e => e.MatriculaAntiga)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA_ANTIGA");

                entity.Property(e => e.Rg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.TxApelido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_APELIDO");

                entity.Property(e => e.TxBilheteServico)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TX_BILHETE_SERVICO");

                entity.Property(e => e.TxCargo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_CARGO");

                entity.Property(e => e.TxCep)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TX_CEP");

                entity.Property(e => e.TxCidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_CIDADE");

                entity.Property(e => e.TxEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_EMAIL");

                entity.Property(e => e.TxEmpresa)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TX_EMPRESA");

                entity.Property(e => e.TxEndereco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_ENDERECO");

                entity.Property(e => e.TxEstado)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TX_ESTADO");

                entity.Property(e => e.TxEstrutura)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TX_ESTRUTURA");

                entity.Property(e => e.TxFax)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TX_FAX");

                entity.Property(e => e.TxFuncao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_FUNCAO");

                entity.Property(e => e.TxMatricAlternativa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TX_MATRIC_ALTERNATIVA");

                entity.Property(e => e.TxNomeusuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_NOMEUSUARIO");

                entity.Property(e => e.TxSiglaArea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TX_SIGLA_AREA");

                entity.Property(e => e.TxSite)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_SITE");

                entity.Property(e => e.TxStatusEmpregado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_STATUS_EMPREGADO");

                entity.Property(e => e.TxTelefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TX_TELEFONE");

                entity.Property(e => e.TxTelefoneCelular)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TX_TELEFONE_CELULAR");

                entity.Property(e => e.TxTipoChefe)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TX_TIPO_CHEFE");

                entity.Property(e => e.TxTipoFuncionario)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TX_TIPO_FUNCIONARIO");

                entity.Property(e => e.TxUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TX_USERNAME");
            });

            modelBuilder.Entity<GrdVwUsuarioFoto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GRD_VW_USUARIO_FOTO");

                entity.Property(e => e.FlTratada)
                    .HasPrecision(1)
                    .HasColumnName("FL_TRATADA");

                entity.Property(e => e.Foto)
                    .HasColumnType("BLOB")
                    .HasColumnName("FOTO");

                entity.Property(e => e.IdCodusuario)
                    .HasPrecision(8)
                    .HasColumnName("ID_CODUSUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}