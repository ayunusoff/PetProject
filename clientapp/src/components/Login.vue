﻿<template>
    <v-card class="mt-10 mx-auto my-12" max-width="80%"  color="light-grey">
        <v-form class="justify-center" v-model="isValid" align="center">
            <v-container fluid style=" width: 100%" align="center">
                <v-row>
                    <v-col align="center" color="red" width="100px" height="100px">
                        <h1>Log In</h1>
                        <h4 v-if="this.useStore.authError">bad pass or nickname</h4>
                    </v-col>
                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-col md="8">
                        <v-text-field id="login"
                                      v-model="form.nickname"
                                      color="green"
                                      :counter="50"
                                      label="nickname"
                                      :rules="titleRules"
                                      required>
                        </v-text-field>
                    </v-col>
                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-col md="8">
                        <v-text-field id="email"
                                      v-model="form.email"
                                      color="green"
                                      :counter="50"
                                      label="email"
                                      :rules="emailRules"
                                      required>
                        </v-text-field>
                    </v-col>
                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-col md="8">
                        
                            <v-text-field 
                                v-model="form.password"
                                :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                                :rules="[rules.required, rules.min, rules.strength]"
                                validate-on-blur
                                :type="showPassword ? 'text' : 'password'"
                                label="Password"
                                class="mb-6"
                                @click:append="showPassword = !showPassword"
                            >
                            </v-text-field>
                            <v-progress-linear 
                                v-model="score.value"
                                :color="score.color"
                                height="10"
                            >
                            </v-progress-linear>
                        
                    </v-col>
                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-btn align="center" :disabled="!isValid" @click="login">Sign in</v-btn>
                </v-row>
                <v-row>
                    <v-col>
                        <router-link to="/account/signup" class="nav-link">
                            <v-btn color="red">
                                Create new account
                            </v-btn>
                        </router-link>
                    </v-col>
                </v-row>
            </v-container>
        </v-form>
    </v-card>
</template>
<script> 
import zxcvbn from 'zxcvbn'
import { useAuthStore } from '@/stores/auth.js';
export default {
    name: 'account-signin',
    setup() {
            const useStore = useAuthStore();
            return { useStore };
        },
        data() {
            return {
                form: {
                    nickname: '',
                    email: '',
                    password: '',
                },
                color: '',
                value: 24,
                showPassword: false,
                isValid: true,
                titleRules: [
                    v => !!v || 'Name is required',
                    v => v.length <= 50 || 'Name must be less than 50 characters',
                ],
                emailRules: [
                    v => !!v || 'E-mail is required',
                    v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
                ],
                rules: {
                    required: value => !!value || 'Enter a password',
                    min: v => v.length >= 8 || 'Use 8 characters or more for your password',
                    strength: v => zxcvbn(v).score >= 3 || 'Please choose a stronger password. Try a mix of letters, numbers, and symbols.',
                },
            }
        },
        computed: {
            score() {
                const result = zxcvbn(this.form.password);

                switch (result.score) {
                    case 4:
                        return {
                            color: "light-blue",
                            value: 100
                        };
                    case 3:
                        return {
                            color: "light-green",
                            value: 75
                        };
                    case 2:
                        return {
                            color: "yellow",
                            value: 50
                        };
                    case 1:
                        return {
                            color: "orange",
                            value: 25
                        };
                    default:
                        return {
                            color: "red",
                            value: 0
                        };
                }
            },
        },
        methods: {
            login() {
                this.useStore.login(this.form);
            }
        }
    }
</script>
<style>
    #login {
        width: 100px;
    }
    .reg-form {
        margin-top: 5%;
        box-shadow: 0 3px 3px #575555 inset;
        width: 50%;
        position: center;
    }
</style>