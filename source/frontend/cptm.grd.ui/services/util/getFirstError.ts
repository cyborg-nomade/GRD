import { CreateProposicaoDto } from "models/proposicoes/proposicao.model";
import { FieldError, FieldErrors } from "react-hook-form";

export const getFirstError = (errors: FieldErrors<CreateProposicaoDto>) => {
    for (const [key, value] of Object.entries(errors)) {
        if ((value as FieldError).type) {
            return key as keyof typeof errors;
        }
    }
    return "titulo" as keyof typeof errors;
};
