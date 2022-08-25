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
import { ObjetoProposicao, ObjetoProposicaoView } from "models/common.model";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";

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
                <Divider textAlign="left">
                    <Typography variant="overline">Dados Gerais</Typography>
                </Divider>
                <Grid container spacing={1}>
                    <Grid xs={12} md={7}>
                        <Controller
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                            control={props.methods.control}
                            name="titulo"
                            render={({
                                field: { onChange, onBlur, value, ref },
                            }) => (
                                <TextField
                                    required
                                    fullWidth
                                    label="Título"
                                    ref={ref}
                                    value={value}
                                    onChange={onChange}
                                    onBlur={onBlur}
                                />
                            )}
                        />
                    </Grid>
                    <Grid xs={12} md={3}>
                        <Controller
                            rules={{
                                required: true,
                            }}
                            control={props.methods.control}
                            name="objeto"
                            render={({
                                field: { onChange, onBlur, value, ref },
                            }) => (
                                <TextField
                                    required
                                    fullWidth
                                    select
                                    label="Objeto"
                                    ref={ref}
                                    value={value}
                                    onChange={onChange}
                                    onBlur={onBlur}
                                >
                                    {ObjetoProposicaoView.map((option) => (
                                        <MenuItem
                                            key={option.value}
                                            value={option.value}
                                        >
                                            {option.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            )}
                        />
                    </Grid>
                    <Grid xs={12} md={2}>
                        <Controller
                            rules={{
                                required: true,
                            }}
                            control={props.methods.control}
                            name="possuiParecerJuridico"
                            render={({
                                field: { onChange, onBlur, value, ref },
                            }) => (
                                <FormGroup>
                                    <FormControlLabel
                                        control={
                                            <Checkbox
                                                checked={value}
                                                onChange={onChange}
                                                onBlur={onBlur}
                                                ref={ref}
                                            />
                                        }
                                        label="Possui Parecer Jurídico?"
                                        labelPlacement="start"
                                    />
                                </FormGroup>
                            )}
                        />
                    </Grid>
                    <Grid xs={12} md={12}>
                        <Controller
                            rules={{
                                required: true,
                            }}
                            control={props.methods.control}
                            name="descricaoProposicao"
                            render={({
                                field: { onChange, onBlur, value, ref },
                            }) => (
                                <TextField
                                    required
                                    fullWidth
                                    multiline
                                    rows={5}
                                    label="Descrição Proposição"
                                    ref={ref}
                                    value={value}
                                    onChange={onChange}
                                    onBlur={onBlur}
                                />
                            )}
                        />
                    </Grid>
                    <Grid xs={12} md={12}>
                        <Controller
                            rules={{
                                required: true,
                            }}
                            control={props.methods.control}
                            name="resumoGeralResolucao"
                            render={({
                                field: { onChange, onBlur, value, ref },
                            }) => (
                                <TextField
                                    required
                                    fullWidth
                                    multiline
                                    rows={3}
                                    label="Resumo Geral da Resolução"
                                    ref={ref}
                                    value={value}
                                    onChange={onChange}
                                    onBlur={onBlur}
                                />
                            )}
                        />
                    </Grid>
                    <Grid xs={12} md={12}>
                        <Controller
                            rules={{
                                required: true,
                            }}
                            control={props.methods.control}
                            name="competenciasConformeNormas"
                            render={({
                                field: { onChange, onBlur, value, ref },
                            }) => (
                                <TextField
                                    required
                                    fullWidth
                                    label="Competência Conforme Normas"
                                    ref={ref}
                                    value={value}
                                    onChange={onChange}
                                    onBlur={onBlur}
                                />
                            )}
                        />
                    </Grid>
                </Grid>
                <Divider textAlign="left">
                    <Typography variant="overline">
                        Contratação / Custos
                    </Typography>
                </Divider>
                <Grid container spacing={1}>
                    <Grid xs={12} md={12}>
                        <Controller
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                            control={props.methods.control}
                            name="observacoesCustos"
                            render={({
                                field: { onChange, onBlur, value, ref },
                            }) => (
                                <TextField
                                    required
                                    fullWidth
                                    label="Observações sobre Custos"
                                    ref={ref}
                                    value={value}
                                    onChange={onChange}
                                    onBlur={onBlur}
                                />
                            )}
                        />
                    </Grid>
                    <Grid xs={12} md={12}>
                        <Controller
                            rules={{
                                required: true,
                                maxLength: 250,
                            }}
                            control={props.methods.control}
                            name="dataBaseValor"
                            render={({
                                field: { onChange, onBlur, value, ref },
                            }) => (
                                <DatePicker
                                    label="Data Base do Valor"
                                    value={value}
                                    onChange={onChange}
                                    renderInput={(params) => (
                                        <TextField {...params} />
                                    )}
                                />
                            )}
                        />
                    </Grid>
                </Grid>
            </Box>
        </Paper>
    );
};

//     dataBaseValor!: Date;
//     receitaDespesa!: ReceitaDespesa;
//     moeda!: string;
//     valorTotalProposicao!: number;
//     valorOriginalContrato!: number;
//     valorAtualContrato!: number;
//     numeroContrato!: string;
//     fornecedor!: string;
//     termo!: string;

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
