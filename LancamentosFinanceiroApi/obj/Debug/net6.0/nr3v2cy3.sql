﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Logins" (
    "Id" bigint GENERATED BY DEFAULT AS IDENTITY,
    "UserName" text NOT NULL,
    "Password" text NOT NULL,
    "RefreshToken" text NOT NULL,
    "RefreshTokenExpiryTibe" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Logins" PRIMARY KEY ("Id")
);

CREATE TABLE "TipoLancamentos" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "DescricaoLancamento" text NOT NULL,
    CONSTRAINT "PK_TipoLancamentos" PRIMARY KEY ("Id")
);

CREATE TABLE "Usuarios" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "CPF" text NOT NULL,
    "DataNascimento" timestamp with time zone NOT NULL,
    "Email" text NOT NULL,
    "Senha" text NOT NULL,
    CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id")
);

CREATE TABLE "Lancamentos" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Valor" double precision NOT NULL,
    "TipoLancamentoId" integer NOT NULL,
    "UsuarioId" integer NOT NULL,
    CONSTRAINT "PK_Lancamentos" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Lancamentos_TipoLancamentos_TipoLancamentoId" FOREIGN KEY ("TipoLancamentoId") REFERENCES "TipoLancamentos" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Lancamentos_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE
);

INSERT INTO "TipoLancamentos" ("Id", "DescricaoLancamento")
VALUES (1, 'Entrada');
INSERT INTO "TipoLancamentos" ("Id", "DescricaoLancamento")
VALUES (2, 'Saída');

CREATE INDEX "IX_Lancamentos_TipoLancamentoId" ON "Lancamentos" ("TipoLancamentoId");

CREATE INDEX "IX_Lancamentos_UsuarioId" ON "Lancamentos" ("UsuarioId");

SELECT setval(
    pg_get_serial_sequence('"TipoLancamentos"', 'Id'),
    GREATEST(
        (SELECT MAX("Id") FROM "TipoLancamentos") + 1,
        nextval(pg_get_serial_sequence('"TipoLancamentos"', 'Id'))),
    false);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220814024100_teste', '6.0.8');

COMMIT;

