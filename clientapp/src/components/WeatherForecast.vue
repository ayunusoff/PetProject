<template>
    <div class="weather">
        <input type="button" name="name" value="GetData" v-on:click="GetWeather()" />

        <br />

        <span>{{data.date}} </span>
    </div>
</template>

<script>

import axios from "axios";
export default {
    data() {
        return {
            data: [] 
        }
    },
    methods: {
        GetWeather() {
            axios.get('/api/WeatherForecast/Get')
            .then(res => 
            {
                this.data = res.data;
            })
            .catch(function (error) 
            {
                alert(error);
            })
        }
}
}
</script>

<style>

</style>