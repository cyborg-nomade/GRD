import Checkbox from "@mui/material/Checkbox";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormGroup from "@mui/material/FormGroup";
import MenuItem from "@mui/material/MenuItem";
import TextField from "@mui/material/TextField";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { CreateProposicaoDto } from "models/proposicoes/proposicao.model";
import React from "react";
import {
    Controller,
    FieldPath,
    RegisterOptions,
    UseFormReturn,
} from "react-hook-form";

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
}) => {
    return (
        <Controller
            rules={props.rules}
            control={props.methods.control}
            name={props.name}
            render={({ field: { onChange, onBlur, value, ref } }) => (
                <React.Fragment>
                    {props.date && (
                        <DatePicker
                            label={props.label}
                            value={value}
                            onChange={onChange}
                            ref={ref}
                            renderInput={(params) => (
                                <TextField
                                    {...params}
                                    id={`data-${props.name}"`}
                                />
                            )}
                        />
                    )}
                    {props.select && props.options && (
                        <TextField
                            required
                            fullWidth
                            select
                            label={props.label}
                            ref={ref}
                            value={value}
                            onChange={onChange}
                            onBlur={onBlur}
                        >
                            {props.options.map((option) => (
                                <MenuItem
                                    key={option.value}
                                    value={option.value}
                                >
                                    {option.label}
                                </MenuItem>
                            ))}
                        </TextField>
                    )}
                    {props.text && (
                        <TextField
                            required
                            fullWidth
                            multiline={props.multiline}
                            rows={props.rows}
                            type={props.typeNumber ? "number" : "text"}
                            label={props.label}
                            ref={ref}
                            value={value}
                            onChange={onChange}
                            onBlur={onBlur}
                        />
                    )}
                    {props.checkbox && (
                        <FormGroup>
                            <FormControlLabel
                                control={
                                    <Checkbox
                                        checked={value as boolean}
                                        onChange={onChange}
                                        onBlur={onBlur}
                                        ref={ref}
                                    />
                                }
                                label={props.label}
                                labelPlacement="start"
                            />
                        </FormGroup>
                    )}
                </React.Fragment>
            )}
        />
    );
};

export default ProposicaoFormItem;
