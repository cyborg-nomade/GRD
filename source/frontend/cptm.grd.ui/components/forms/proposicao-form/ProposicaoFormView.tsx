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

const ProposicaoFormView = (props: {
    saveProposicaoHandler: (proposicao: CreateProposicaoDto) => {};
    methods: UseFormReturn<CreateProposicaoDto>;
    isLoading: boolean;
    isWarning: boolean;
    error: any;
    clearError: () => void;
}) => {
    return (
        <Paper
            component="form"
            sx={{ padding: "10px", margin: "auto", width: "100%" }}
            onSubmit={props.methods.handleSubmit(props.saveProposicaoHandler)}
        >
            <Box sx={{ flexGrow: 1 }}>
                <FormTitleDivider title="Dados Gerais" />
                <Grid container spacing={1}>
                    <Grid xs={12} md={7}>
                        <ProposicaoFormItem
                            label="Título"
                            methods={props.methods}
                            name="titulo"
                            text
                            rules={{ required: true, maxLength: 250 }}
                        />
                    </Grid>
                    <Grid xs={12} md={3}>
                        <ProposicaoFormItem
                            label="Objeto"
                            methods={props.methods}
                            name="objeto"
                            select
                            options={ObjetoProposicaoView}
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Possui Parecer Jurídico?"
                            methods={props.methods}
                            name="possuiParecerJuridico"
                            checkbox
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={12}>
                        <ProposicaoFormItem
                            label="Descrição Proposição"
                            methods={props.methods}
                            name="descricaoProposicao"
                            text
                            multiline
                            rows={5}
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={12}>
                        <ProposicaoFormItem
                            label="Resumo Geral da Resolução"
                            methods={props.methods}
                            name="resumoGeralResolucao"
                            text
                            multiline
                            rows={3}
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={12}>
                        <ProposicaoFormItem
                            label="Competência Conforme Normas"
                            methods={props.methods}
                            name="competenciasConformeNormas"
                            text
                            rules={{ required: true }}
                        />
                    </Grid>
                </Grid>
                <FormTitleDivider title="Contratação / Custos" />
                <Grid container spacing={1}>
                    <Grid xs={12} md={12}>
                        <ProposicaoFormItem
                            label="Observações sobre Custos"
                            methods={props.methods}
                            name="observacoesCustos"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Data Base do Valor"
                            methods={props.methods}
                            name="dataBaseValor"
                            date
                            rules={{
                                required: true,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Receita/Despesa"
                            methods={props.methods}
                            name="receitaDespesa"
                            select
                            options={ReceitaDespesaView}
                            rules={{
                                required: true,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={1}>
                        <ProposicaoFormItem
                            label="Moeda"
                            methods={props.methods}
                            name="moeda"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={3}>
                        <ProposicaoFormItem
                            label="Valor Total da Proposição"
                            methods={props.methods}
                            name="valorTotalProposicao"
                            text
                            typeNumber
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Valor Original do Contrato"
                            methods={props.methods}
                            name="valorOriginalContrato"
                            text
                            typeNumber
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Valor Atual do Contrato"
                            methods={props.methods}
                            name="valorAtualContrato"
                            text
                            typeNumber
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={4}>
                        <ProposicaoFormItem
                            label="Número do Contrato"
                            methods={props.methods}
                            name="numeroContrato"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={4}>
                        <ProposicaoFormItem
                            label="Fornecedor"
                            methods={props.methods}
                            name="fornecedor"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={4}>
                        <ProposicaoFormItem
                            label="Termo"
                            methods={props.methods}
                            name="termo"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                </Grid>
                <FormTitleDivider title="Reserva de Verba" />
                <Grid container spacing={1}>
                    <Grid xs={12} md={12}>
                        <ProposicaoFormItem
                            label="Observações sobre Custos"
                            methods={props.methods}
                            name="observacoesCustos"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Data Base do Valor"
                            methods={props.methods}
                            name="dataBaseValor"
                            date
                            rules={{
                                required: true,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Receita/Despesa"
                            methods={props.methods}
                            name="receitaDespesa"
                            select
                            options={ReceitaDespesaView}
                            rules={{
                                required: true,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={1}>
                        <ProposicaoFormItem
                            label="Moeda"
                            methods={props.methods}
                            name="moeda"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={3}>
                        <ProposicaoFormItem
                            label="Valor Total da Proposição"
                            methods={props.methods}
                            name="valorTotalProposicao"
                            text
                            typeNumber
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Valor Original do Contrato"
                            methods={props.methods}
                            name="valorOriginalContrato"
                            text
                            typeNumber
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <ProposicaoFormItem
                            label="Valor Atual do Contrato"
                            methods={props.methods}
                            name="valorAtualContrato"
                            text
                            typeNumber
                            rules={{ required: true }}
                        />
                    </Grid>
                    <Grid xs={12} md={4}>
                        <ProposicaoFormItem
                            label="Número do Contrato"
                            methods={props.methods}
                            name="numeroContrato"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={4}>
                        <ProposicaoFormItem
                            label="Fornecedor"
                            methods={props.methods}
                            name="fornecedor"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                    <Grid xs={12} md={4}>
                        <ProposicaoFormItem
                            label="Termo"
                            methods={props.methods}
                            name="termo"
                            text
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                        />
                    </Grid>
                </Grid>
            </Box>
        </Paper>
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
