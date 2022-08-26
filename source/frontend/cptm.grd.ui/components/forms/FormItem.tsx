import React from "react";
import {
    FieldPath,
    FieldValues,
    RegisterOptions,
    UseFormReturn,
    Controller,
} from "react-hook-form";
import Checkbox from "@mui/material/Checkbox";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormGroup from "@mui/material/FormGroup";
import InputAdornment from "@mui/material/InputAdornment";
import MenuItem from "@mui/material/MenuItem";
import TextField from "@mui/material/TextField";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import Grid from "@mui/material/Unstable_Grid2";
import { FileCopy } from "@mui/icons-material";

export type FormItemProps<T extends FieldValues> = {
    label: string;
    name: FieldPath<T>;
    methods: UseFormReturn<T>;
    rules?: RegisterOptions;
    date?: boolean;
    select?: boolean;
    options?: { label: string; value: number }[];
    text?: boolean;
    multiline?: boolean;
    rows?: number;
    typeNumber?: boolean;
    checkbox?: boolean;
    file?: boolean;
    multiFile?: boolean;
    gridSizeSmall: number;
    gridSizeLarge: number;
    disabled?: boolean;
    required?: boolean;
};

const FormItem = <T extends FieldValues>(props: FormItemProps<T>) => {
    return (
        <Grid xs={props.gridSizeSmall} md={props.gridSizeLarge}>
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
                                        required={props.required}
                                        disabled={props.disabled}
                                    />
                                )}
                            />
                        )}
                        {props.select && props.options && (
                            <TextField
                                disabled={props.disabled}
                                required={props.required}
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
                                disabled={props.disabled}
                                required={props.required}
                                fullWidth
                                multiline={props.multiline}
                                rows={props.rows}
                                type={props.typeNumber ? "number" : "text"}
                                label={props.label}
                                ref={ref}
                                value={value}
                                onChange={onChange}
                                onBlur={onBlur}
                                InputProps={
                                    props.typeNumber
                                        ? {
                                              startAdornment: (
                                                  <InputAdornment position="start">
                                                      R$
                                                  </InputAdornment>
                                              ),
                                          }
                                        : {}
                                }
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
                                            disabled={props.disabled}
                                            required={props.required}
                                        />
                                    }
                                    label={props.label}
                                    labelPlacement="start"
                                />
                            </FormGroup>
                        )}
                        {props.file && (
                            <TextField
                                disabled={props.disabled}
                                required={props.required}
                                fullWidth
                                type="file"
                                label={props.label}
                                ref={ref}
                                value={value}
                                onChange={onChange}
                                onBlur={onBlur}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <FileCopy />
                                        </InputAdornment>
                                    ),
                                }}
                                inputProps={
                                    props.multiFile ? { multiple: true } : {}
                                }
                            />
                        )}
                    </React.Fragment>
                )}
            />
        </Grid>
    );
};

export default FormItem;
