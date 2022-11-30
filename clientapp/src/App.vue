<template>
  <ProductListElement/>
  <WeatherForecast/>
</template>

<script>
import ProductListElement from './components/ProductListElement.vue';
import WeatherForecast from './components/WeatherForecast.vue'

export default {
  name: 'App',
  components: {
    WeatherForecast,
    ProductListElement
}
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
