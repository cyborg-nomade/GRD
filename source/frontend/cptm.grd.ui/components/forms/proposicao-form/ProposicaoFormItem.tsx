import { CreateProposicaoDto } from "models/proposicoes/proposicao.model";
import React from "react";
import { FieldPath, RegisterOptions, UseFormReturn } from "react-hook-form";
import FormItem, { FormItemProps } from "../FormItem";

const ProposicaoFormItem = (props: FormItemProps<CreateProposicaoDto>) => {
    return <FormItem<CreateProposicaoDto> {...props} />;
};

export default ProposicaoFormItem;
