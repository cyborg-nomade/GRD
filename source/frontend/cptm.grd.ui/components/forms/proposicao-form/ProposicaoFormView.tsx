import {
    Box,
    Checkbox,
    Chip,
    Divider,
    FormControlLabel,
    FormGroup,
    MenuItem,
    Paper,
    TextField,
    Typography,
} from "@mui/material";
import {
    CreateProposicaoDto,
    ProposicaoDto,
} from "models/proposicoes/proposicao.model";
import React from "react";
import { Controller, UseFormReturn } from "react-hook-form";
import Grid from "@mui/material/Unstable_Grid2";
import {
    ObjetoProposicao,
    ObjetoProposicaoView,
    ReceitaDespesaView,
} from "models/common.model";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import ProposicaoFormItem from "./ProposicaoFormItem";
import FormTitleDivider from "../FormTitleDivider";
import FormSection from "../FormSection";
import FormPaper from "../FormPaper";

const ProposicaoFormView = (props: {
    saveProposicaoHandler: (proposicao: CreateProposicaoDto) => {};
    methods: UseFormReturn<CreateProposicaoDto>;
    isLoading: boolean;
    isWarning: boolean;
    error: any;
    clearError: () => void;
}) => {
    return (
        <FormPaper
            submitHandler={props.methods.handleSubmit(
                props.saveProposicaoHandler
            )}
        >
            <FormSection title="Dados Gerais">
                <ProposicaoFormItem
                    label="Título"
                    methods={props.methods}
                    name="titulo"
                    text
                    rules={{ required: true, maxLength: 250 }}
                    gridSizeLarge={7}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Objeto"
                    methods={props.methods}
                    name="objeto"
                    select
                    options={ObjetoProposicaoView}
                    rules={{ required: true }}
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Possui Parecer Jurídico?"
                    methods={props.methods}
                    name="possuiParecerJuridico"
                    checkbox
                    rules={{ required: true }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Descrição Proposição"
                    methods={props.methods}
                    name="descricaoProposicao"
                    text
                    multiline
                    rows={5}
                    rules={{ required: true }}
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Resumo Geral da Resolução"
                    methods={props.methods}
                    name="resumoGeralResolucao"
                    text
                    multiline
                    rows={3}
                    rules={{ required: true }}
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Competência Conforme Normas"
                    methods={props.methods}
                    name="competenciasConformeNormas"
                    text
                    rules={{ required: true }}
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                />
            </FormSection>
            <FormSection title="Contratação / Custos">
                <ProposicaoFormItem
                    label="Observações sobre Custos"
                    methods={props.methods}
                    name="observacoesCustos"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Data Base do Valor"
                    methods={props.methods}
                    name="dataBaseValor"
                    date
                    rules={{
                        required: true,
                    }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Receita/Despesa"
                    methods={props.methods}
                    name="receitaDespesa"
                    select
                    options={ReceitaDespesaView}
                    rules={{
                        required: true,
                    }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Moeda"
                    methods={props.methods}
                    name="moeda"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={1}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Valor Total da Proposição"
                    methods={props.methods}
                    name="valorTotalProposicao"
                    text
                    typeNumber
                    rules={{ required: true }}
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Valor Original do Contrato"
                    methods={props.methods}
                    name="valorOriginalContrato"
                    text
                    typeNumber
                    rules={{ required: true }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Valor Atual do Contrato"
                    methods={props.methods}
                    name="valorAtualContrato"
                    text
                    typeNumber
                    rules={{ required: true }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Número do Contrato"
                    methods={props.methods}
                    name="numeroContrato"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={4}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Fornecedor"
                    methods={props.methods}
                    name="fornecedor"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={4}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Termo"
                    methods={props.methods}
                    name="termo"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={4}
                    gridSizeSmall={12}
                />
            </FormSection>
            <FormSection title="Reserva de Verba">
                <ProposicaoFormItem
                    label="Número da Reserva de Verba"
                    methods={props.methods}
                    name="numeroReservaVerba"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Valor da Reserva de Verba"
                    methods={props.methods}
                    name="valorReservaVerba"
                    text
                    typeNumber
                    rules={{
                        required: true,
                    }}
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Receita/Despesa"
                    methods={props.methods}
                    name="receitaDespesa"
                    select
                    options={ReceitaDespesaView}
                    rules={{
                        required: true,
                    }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Moeda"
                    methods={props.methods}
                    name="moeda"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={1}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Valor Total da Proposição"
                    methods={props.methods}
                    name="valorTotalProposicao"
                    text
                    typeNumber
                    rules={{ required: true }}
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Valor Original do Contrato"
                    methods={props.methods}
                    name="valorOriginalContrato"
                    text
                    typeNumber
                    rules={{ required: true }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Valor Atual do Contrato"
                    methods={props.methods}
                    name="valorAtualContrato"
                    text
                    typeNumber
                    rules={{ required: true }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Número do Contrato"
                    methods={props.methods}
                    name="numeroContrato"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={4}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Fornecedor"
                    methods={props.methods}
                    name="fornecedor"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={4}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Termo"
                    methods={props.methods}
                    name="termo"
                    text
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    gridSizeLarge={4}
                    gridSizeSmall={12}
                />
            </FormSection>
        </FormPaper>
    );
};

//     numeroReservaVerba!: string;
//     valorReservaVerba!: number;
//     inicioVigenciaReserva!: Date;
//     fimVigenciaReserva!: Date;

//     numeroProposicao!: string;
//     protocoloExpediente!: string;
//     numeroProcessoLicit!: string;

//     outrasObservacoes?: string | undefined;
//     numeroConselho?: string | undefined;

//     sinteseProcessoFilePath!: string;
//     notaTecnicaFilePath!: string;
//     prdFilePath!: string;
//     parecerJuridicoFilePath!: string;
//     trFilePath!: string;
//     relatorioTecnicoFilePath!: string;
//     planilhaQuantFilePath!: string;
//     editalFilePath!: string;
//     reservaVerbaFilePath!: string;
//     scFilePath!: string;
//     ravFilePath!: string;
//     cronogramaFisFinFilePath!: string;
//     pcaFilePath!: string;
//     outrosFilePath!: string[];

//     seq!: number;

//     criador!: UserDto;
//     area!: GroupDto;

export default ProposicaoFormView;
