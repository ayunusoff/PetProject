<template>
  <div class="list-element">
    <label>name</label>
    <input type="text" v-model="product.name">

    <label>desc</label>
    <input type="text" v-model="product.description">

    <label>cost</label>
    <input type="text" v-model="product.cost">
    <button v-on:click="submit()">Submit</button>
    <ul>
      <li 
        v-for="product in products"
        :key="product.id"
      >
        
      {{product.name}}
      {{product.description}}
      {{product.cost}}
      </li>
    </ul>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      products: [],
      product: {
        name: '',
        description: '',
        cost: 0
      }
    }
  },
  methods: {
    submit() {
      axios.post("/api/Product/Post", this.product)
      .then(
        (response) => 
        {
          this.products = response.data;
        }, 
        (error) => 
        {
          console.log(error);
        }
      );
    }
  },
  mounted () {
    axios.get("/api/Product/Get")
      .then(
        (response) => 
        {
            this.products = response.data;
        }, 
        (error) => 
        {
          console.log(error);
        }
      );
  }
}
</script>

<style>

</style>