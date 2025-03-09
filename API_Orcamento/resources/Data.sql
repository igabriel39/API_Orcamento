CREATE OR REPLACE TABLE tbUnidade (
  ID int IDENTITY(1,1) NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_Unidade PRIMARY KEY (ID)
);
CREATE OR REPLACE TABLE tbTipoLancamento (
  ID int IDENTITY(1,1) NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_TipoLancamento PRIMARY KEY (ID)
);
CREATE OR REPLACE TABLE tbSolicitante (
  ID int IDENTITY(1,1) NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_Solicitante PRIMARY KEY (ID)
);
CREATE OR REPLACE TABLE tbObjetivoEstrategico (
  ID int IDENTITY(1,1) NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_ObjetivoEstrategico PRIMARY KEY (ID)
);
CREATE OR REPLACE TABLE tbUnidadeOrcamentaria (
  ID int IDENTITY(1,1) NOT NULL,
  Codigo int NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_UnidadeOrcamentaria PRIMARY KEY (ID),
  CONSTRAINT UQ_UnidadeOrcamentaria UNIQUE (Codigo)
);
CREATE OR REPLACE TABLE tbPrograma (
  ID int IDENTITY(1,1) NOT NULL,
  Codigo int NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_Programa PRIMARY KEY (ID),
  CONSTRAINT UQ_Programa UNIQUE (Codigo)
);
CREATE OR REPLACE TABLE tbFonteRecurso (
  ID int IDENTITY(1,1) NOT NULL,
  Codigo int NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_FonteRecurso PRIMARY KEY (ID),
  CONSTRAINT UQ_FonteRecurso UNIQUE (Codigo)
);
CREATE OR REPLACE TABLE tbAcao (
  ID int IDENTITY(1,1) NOT NULL,
  Codigo int NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_Acao PRIMARY KEY (ID),
  CONSTRAINT UQ_Acao UNIQUE (Codigo)
);
CREATE OR REPLACE TABLE tbGrupoDespesa (
  ID int IDENTITY(1,1) NOT NULL,
  Codigo float NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_GrupoDespesa PRIMARY KEY (ID),
  CONSTRAINT UQ_GrupoDespesa UNIQUE (Codigo)
);
CREATE OR REPLACE TABLE tbModalidadeAplicacao (
  ID int IDENTITY(1,1) NOT NULL,
  Codigo int NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_ModalidadeAplicacao PRIMARY KEY (ID),
  CONSTRAINT UQ_ModalidadeAplicacao UNIQUE (Codigo)
);
CREATE OR REPLACE TABLE tbElementoDespesa (
  ID int IDENTITY(1,1) NOT NULL,
  Codigo int NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_ElementoDespesa PRIMARY KEY (ID),
  CONSTRAINT UQ_ElementoDespesa UNIQUE (Codigo)
);
CREATE OR REPLACE TABLE tbTipoTransacao (
  ID int IDENTITY(1,1) NOT NULL,
  Nome varchar(255) NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  CONSTRAINT PK_TipoTransacao PRIMARY KEY (ID)
);
CREATE OR REPLACE TABLE tbLancamentos (
  ID int IDENTITY(1,1) NOT NULL,
  LancamentoValido bit NOT NULL,
  NumeroLancamento int NULL,
  IDTipoLancamento int NOT NULL,
  DataLancamento date NOT NULL,
  IDLancamentoPai int NULL,
  IDUnidade int NOT NULL,
  Descricao varchar(255) NOT NULL,
  IDUnidadeOrcamentaria int NOT NULL,
  IDPrograma int NOT NULL,
  IDAcao int NOT NULL,
  IDFonteRecurso int NOT NULL,
  IDGrupoDespesa int NOT NULL,
  IDModalidadeAplicacao int NOT NULL,
  IDElementoDespesa int NOT NULL,
  IDSolicitante int NULL,
  GED varchar(27) NULL,
  Contratado varchar(255) NULL,
  IDObjetivoEstrategico int NULL,
  Valor real NOT NULL,
  IDTipoTransacao int NOT NULL,
  DataCadastro datetime NOT NULL,
  DataAlteracao datetime NULL,
  AnoOrcamento smallint NOT NULL,
  CONSTRAINT PK_Lancamentos PRIMARY KEY (ID),
  CONSTRAINT fk_Lancamentos_TipoLancamento FOREIGN KEY (IDTipoLancamento) REFERENCES tbTipoLancamento (ID),
  CONSTRAINT fk_Lancamentos_Unidade FOREIGN KEY (IDUnidade) REFERENCES tbUnidade (ID),
  CONSTRAINT fk_Lancamentos_UnidadeOrcamentaria FOREIGN KEY (IDUnidadeOrcamentaria) REFERENCES tbUnidadeOrcamentaria (ID),
  CONSTRAINT fk_Lancamentos_ElementoDespesa FOREIGN KEY (IDElementoDespesa) REFERENCES tbElementoDespesa (ID),
  CONSTRAINT fk_Lancamentos_Acao FOREIGN KEY (IDAcao) REFERENCES tbAcao (ID),
  CONSTRAINT fk_Lancamentos_Programa FOREIGN KEY (IDPrograma) REFERENCES tbPrograma (ID),
  CONSTRAINT fk_Lancamentos_Solicitante FOREIGN KEY (IDSolicitante) REFERENCES tbSolicitante (ID),
  CONSTRAINT fk_Lancamentos_ObjetivoEstrategico FOREIGN KEY (IDObjetivoEstrategico) REFERENCES tbObjetivoEstrategico (ID),
  CONSTRAINT fk_Lancamentos_GrupoDespesa FOREIGN KEY (IDGrupoDespesa) REFERENCES tbGrupoDespesa (ID),
  CONSTRAINT fk_Lancamentos_ModalidadeAplicacao FOREIGN KEY (IDModalidadeAplicacao) REFERENCES tbModalidadeAplicacao (ID),
  CONSTRAINT fk_Lancamentos_TipoTransacao FOREIGN KEY (IDTipoTransacao) REFERENCES tbTipoTransacao (ID),
  CONSTRAINT fk_Lancamentos_FonteRecurso FOREIGN KEY (IDFonteRecurso) REFERENCES tbFonteRecurso (ID),
  CONSTRAINT fk_Lancamentos_Lancamentos FOREIGN KEY (IDLancamentoPai) REFERENCES tbLancamentos (ID)
);