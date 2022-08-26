import { CreateProposicaoDto } from "models/proposicoes/proposicao.model";
import React from "react";
import { UseFormReturn } from "react-hook-form";
import { ObjetoProposicaoView, ReceitaDespesaView } from "models/common.model";
import ProposicaoFormItem from "./ProposicaoFormItem";
import FormSection from "../FormSection";
import FormPaper from "../FormPaper";
import { useAppSelector } from "services/redux/hooks";

const ProposicaoFormView = (props: {
    saveProposicaoHandler: (proposicao: CreateProposicaoDto) => {};
    methods: UseFormReturn<CreateProposicaoDto>;
    isLoading: boolean;
    isWarning: boolean;
    error: any;
    clearError: () => void;
}) => {
    const authState = useAppSelector((state) => state.auth);

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
                    label="Área"
                    methods={props.methods}
                    name="area"
                    select
                    options={authState.currentUser.areasAcesso.map((area) => {
                        return { label: area.sigla, value: area.id };
                    })}
                    gridSizeLarge={3}
                    gridSizeSmall={12}
                />
                <ProposicaoFormItem
                    label="Outras Observações"
                    methods={props.methods}
                    name="outrasObservacoes"
                    text
                    gridSizeLarge={9}
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
            <FormSection title="Anexos">
                <ProposicaoFormItem
                    label="Síntese do Processo"
                    methods={props.methods}
                    name="sinteseProcessoFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Nota Técnica"
                    methods={props.methods}
                    name="notaTecnicaFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="PRD"
                    methods={props.methods}
                    name="prdFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Parecer Jurídico"
                    methods={props.methods}
                    name="parecerJuridicoFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Termo de Referência"
                    methods={props.methods}
                    name="trFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Relatório Técnico"
                    methods={props.methods}
                    name="relatorioTecnicoFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Planilha Quantitativa"
                    methods={props.methods}
                    name="planilhaQuantFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Edital"
                    methods={props.methods}
                    name="editalFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Reserva de Verba"
                    methods={props.methods}
                    name="reservaVerbaFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="SC"
                    methods={props.methods}
                    name="scFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="RAV"
                    methods={props.methods}
                    name="ravFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Cronograma Físico-Financeiro"
                    methods={props.methods}
                    name="cronogramaFisFinFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="PCA"
                    methods={props.methods}
                    name="pcaFilePath"
                    file
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
                <ProposicaoFormItem
                    label="Outros"
                    methods={props.methods}
                    name="outrosFilePath"
                    file
                    multiFile
                    gridSizeLarge={12}
                    gridSizeSmall={12}
                    required
                />
            </FormSection>
        </FormPaper>
    );
};

export default ProposicaoFormView;
