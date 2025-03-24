﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Orcamento.Migrations
{
    /// <inheritdoc />
    public partial class dataAlteracaoNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbLancamentos_LancamentoId",
                table: "tbLancamentos");

            migrationBuilder.AlterColumn<int>(
                name: "LancamentoId",
                table: "tbLancamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "tbLancamentos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbLancamentos_LancamentoId",
                table: "tbLancamentos",
                column: "LancamentoId",
                principalTable: "tbLancamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbLancamentos_LancamentoId",
                table: "tbLancamentos");

            migrationBuilder.AlterColumn<int>(
                name: "LancamentoId",
                table: "tbLancamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "tbLancamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbLancamentos_LancamentoId",
                table: "tbLancamentos",
                column: "LancamentoId",
                principalTable: "tbLancamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
