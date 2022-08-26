import { CreateProposicaoDto } from "models/proposicoes/proposicao.model";
import React from "react";
import { UseFormReturn } from "react-hook-form";
import { ObjetoProposicaoView, ReceitaDespesaView } from "models/common.model";
import ProposicaoFormItem from "./ProposicaoFormItem";
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
                    required
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
                    required
                />
                <ProposicaoFormItem
                    label="Possui Parecer Jurídico?"
                    methods={props.methods}
                    name="possuiParecerJuridico"
                    checkbox
                    rules={{ required: true }}
                    gridSizeLarge={2}
                    gridSizeSmall={12}
                    required
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
                    required
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
                    required
                />
                <ProposicaoFormItem
                    label="Competência Conforme Normas"
                    methods={props.methods}
                    name="competenciasConformeNormas"
                    text
                    rules={{ required: true }}
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
            </FormSection>
            <FormSection title="Identificação">
                <ProposicaoFormItem
                    label="Nº da Proposição"
                    methods={props.methods}
                    name="numeroProposicao"
                    text
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                    disabled
                />
                <ProposicaoFormItem
                    label="Protocolo / Expediente"
                    methods={props.methods}
                    name="protocoloExpediente"
                    text
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                    rules={{ required: true, maxLength: 250 }}
                    required
                />
                <ProposicaoFormItem
                    label="Nº Processo Licitatório"
                    methods={props.methods}
                    name="numeroProcessoLicit"
                    text
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                    rules={{ required: true, maxLength: 250 }}
                    required
                />
                <ProposicaoFormItem
                    label="Nº do Conselho"
                    methods={props.methods}
                    name="numeroConselho"
                    text
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Outras Observações"
                    methods={props.methods}
                    name="outrasObservacoes"
                    text
                    multiline
                    rows={2}
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
                    required
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
                    required
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
                    required
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
                    required
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
                    required
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
                    required
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
                    required
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
                    required
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
                    required
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
                    required
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
                    required
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
                    required
                />
                <ProposicaoFormItem
                    label="Início da Vigência da Reserva de Verba"
                    methods={props.methods}
                    name="inicioVigenciaReserva"
                    date
                    rules={{
                        required: true,
                    }}
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Fim da Vigência da Reserva de Verba"
                    methods={props.methods}
                    name="fimVigenciaReserva"
                    date
                    rules={{
                        required: true,
                    }}
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                    required
                />
            </FormSection>
        </FormPaper>
    );
};

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
