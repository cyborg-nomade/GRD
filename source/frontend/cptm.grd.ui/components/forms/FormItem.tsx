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
import { useAppSelector } from "services/redux/hooks";
import _ from "lodash";
import { FormControl, FormHelperText, FormLabel } from "@mui/material";

export type FormItemProps<T extends FieldValues> = {
    label: string;
    name: FieldPath<T>;
    methods: UseFormReturn<T>;
    rules?: RegisterOptions;
    date?: boolean;
    select?: boolean;
    selectArea?: boolean;
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
    const authState = useAppSelector((state) => state.auth);

    return (
        <Grid
            xs={props.gridSizeSmall}
            md={props.gridSizeLarge}
            container={props.checkbox}
            direction={"row"}
            alignItems={"center"}
            justifyContent={"flex-end"}
            pr={props.checkbox ? "10px" : undefined}
        >
            <Controller
                rules={props.rules}
                control={props.methods.control}
                name={props.name}
                render={({
                    field: { onChange, onBlur, value, ref },
                    fieldState: { error },
                }) => (
                    <React.Fragment>
                        {props.date && (
                            <DatePicker
                                label={props.label}
                                value={value}
                                onChange={onChange}
                                renderInput={(params) => (
                                    <TextField
                                        {...params}
                                        id={`data-${props.name}"`}
                                        required={props.required}
                                        disabled={props.disabled}
                                        error={!!error}
                                        inputRef={ref}
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
                                inputRef={ref}
                                value={value}
                                onChange={onChange}
                                onBlur={onBlur}
                                error={!!error}
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
                        {props.selectArea && (
                            <TextField
                                disabled={props.disabled}
                                required={props.required}
                                fullWidth
                                select
                                label={props.label}
                                inputRef={ref}
                                value={value.id || ""}
                                onChange={(val) => {
                                    console.log(val);
                                    console.log(
                                        authState.currentUser.areasAcesso.find(
                                            (o) => o.id === +val.target.value
                                        )
                                    );

                                    return onChange(
                                        authState.currentUser.areasAcesso.find(
                                            (o) => o.id === +val.target.value
                                        )
                                    );
                                }}
                                onBlur={onBlur}
                                error={!!error}
                            >
                                {authState.currentUser.areasAcesso.map(
                                    (option) => (
                                        <MenuItem
                                            key={option.id}
                                            value={option.id}
                                        >
                                            {option.sigla}
                                        </MenuItem>
                                    )
                                )}
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
                                inputRef={ref}
                                value={value}
                                onChange={onChange}
                                onBlur={onBlur}
                                error={!!error}
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
                            <FormControl
                                required={props.required}
                                error={!!error}
                                component="fieldset"
                                variant="standard"
                            >
                                <FormGroup>
                                    <FormLabel component="legend">
                                        Parecer Jurídico
                                    </FormLabel>
                                    <FormControlLabel
                                        control={
                                            <Checkbox
                                                checked={value as boolean}
                                                onChange={onChange}
                                                onBlur={onBlur}
                                                inputRef={ref}
                                                disabled={props.disabled}
                                                required={props.required}
                                                sx={{
                                                    color: !!error
                                                        ? "#d32f2f"
                                                        : "#000000de",
                                                }}
                                            />
                                        }
                                        label={props.label}
                                        labelPlacement="start"
                                        sx={{
                                            color: !!error
                                                ? "#d32f2f"
                                                : "#000000de",
                                        }}
                                    />
                                </FormGroup>
                                {!!_.get(
                                    props.methods.formState.errors,
                                    props.name
                                ) && (
                                    <FormHelperText>
                                        Este campo é obrigatório
                                    </FormHelperText>
                                )}
                            </FormControl>
                        )}
                        {props.file && (
                            <TextField
                                disabled={props.disabled}
                                required={props.required}
                                fullWidth
                                type="file"
                                label={props.label}
                                inputRef={ref}
                                value={value}
                                onChange={
                                    props.multiFile
                                        ? (val) => {
                                              value.push(val.target.value);
                                          }
                                        : onChange
                                }
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
                                error={!!error}
                            />
                        )}
                    </React.Fragment>
                )}
            />
        </Grid>
    );
};

export default FormItem;
