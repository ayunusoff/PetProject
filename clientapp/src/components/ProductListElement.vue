<template>

  <div class="list-element">
    <select v-model="sortMethod">
      <option selected="selected">По-умолчанию</option>
      <option>По-возрастанию</option>
      <option>По-убыванию</option>
      <option>По-алфавиту</option>
    </select>
  </div>
  <div class="container content">
	<div class="row">
      
    <div class="col-md-10 products">
        <div class="row">
          <div class="col-sm-3" v-for="product in products" :key="product.id">
            <div class="product">
              <div class="product-img">
                <a href="#"><img :src="product.imgSrc" alt=""></a>
              </div>
              <p class="product-title">
                <a href="#">{{product.name}}</a>
              </p>
              <p class="product-desc">{{product.description}}</p>
              <p class="product-price">{{product.cost}}</p>
            </div>
          </div>
        </div>
      </div>
  </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      sortMethod: '',
      products: [],
      product: {
        name: '',
        imgSrc: '',
        description: '',
        cost: 0
      }
    }
  },
  methods: {
    
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
body{
	background: #ececec;
}
img {
	height: auto;
	max-width: 100%;
}
.content{
	margin-top: 50px;
}
.product {
	background: #fff none repeat scroll 0 0;
	border: 1px solid #c0c0c0;
	height: 390px;
	overflow: hidden;
	padding: 25px 15px;
	position: relative;
	text-align: center;
	transition: all 0.5s ease 0s;
	margin-bottom: 20px;
}
.product:hover {
	box-shadow: 0 0 16px rgba(0, 0, 0, 0.5);
}
.product-img {
	height: 200px;
}
.product-title a {
	color: #000;
	font-weight: 500;
	text-transform: uppercase;
}
.product-desc {
	max-height: 60px;
	overflow: hidden;
}
.product-price {
	bottom: 15px;
	left: 0;
	position: absolute;
	width: 100%;
	color: #d51e08;
	font-size: 18px;
	font-weight: 500;
}

</style>