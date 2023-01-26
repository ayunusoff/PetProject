<template>
    <v-card class="mt-10 mx-auto my-12" width="50%" color="light-grey" align="center">
        <v-form v-model="isValid" text-align="center">
            <v-container fluid style=" width: 100%" align="center">
                <v-row>
                    <v-col color="red" width="100px" height="100px">

                        <v-avatar size="200" color="teal">
                            <img contain
                                 :src="form.imgSrc"
                                 height="500"
                                 size="250"
                                 alt="">
                        </v-avatar>
                    </v-col>

                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-col md="8" align="center">
                        <v-text-field id="imgsrc"
                                      v-model="form.imgSrc"
                                      color="green"
                                      :counter="50"
                                      max-width="100px"
                                      label="User image src"
                                      >

                        </v-text-field>
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
                    <v-btn align="center" :disabled="!isValid" @click="reg">Sign up</v-btn>
                </v-row>
                
            </v-container>
        </v-form>
    </v-card>
</template>
<script>
    import zxcvbn from 'zxcvbn'
    import { useAuthStore } from '@/stores/auth';
    export default {
        name: 'account-signup',
        setup() {
            const userStore = useAuthStore();
            return { userStore };
        },
        data() {
            return {
                form: {
                    nickname: '',
                    email: '',
                    password: '',
                    imgSrc: '',
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
            async reg() {
                await this.userStore.registration(this.form);
            }
        }
    }
</script>
<style>
    
</style>