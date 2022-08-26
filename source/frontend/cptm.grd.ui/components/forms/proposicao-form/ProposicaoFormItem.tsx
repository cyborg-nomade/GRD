import { CreateProposicaoDto } from "models/proposicoes/proposicao.model";
import React from "react";
import { FieldPath, RegisterOptions, UseFormReturn } from "react-hook-form";
import FormItem from "../FormItem";

const ProposicaoFormItem = (props: {
    label: string;
    name: FieldPath<CreateProposicaoDto>;
    methods: UseFormReturn<CreateProposicaoDto>;
    rules?: RegisterOptions;
    date?: boolean;
    select?: boolean;
    options?: { label: string; value: number }[];
    text?: boolean;
    multiline?: boolean;
    rows?: number;
    typeNumber?: boolean;
    checkbox?: boolean;
    gridSizeSmall: number;
    gridSizeLarge: number;
}) => {
    return <FormItem<CreateProposicaoDto> {...props} />;
};

export default ProposicaoFormItem;
