<template>
    <nav class="navbar navbar-dark bg-primary fixed-top">
        <div class="container">
            <a class="navbar-brand" href="#">Pet-Project</a>
            <div class="menu-bar" v-on:click="menuButtonClick()">
                <span></span>
            </div>
            <div class="menu">
            
            </div>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
        </div>
    </nav>
    </template>
    
    <script>
       export default {
            data() {
                
            },
            methods: {
                menuButtonClick() {
                    document.querySelector('.menu-bar span').classList.toggle('active');
                    document.querySelector('.menu').classList.toggle('animate');
                }
            }
        }
    </script>
    
    <style>
        .navbar {
            background: -webkit-linear-gradient(90deg, rgb(169, 210, 236), rgb(165, 202, 225));
    background: -moz-linear-gradient(90deg, rgb(169, 210, 236), rgb(165, 202, 225));
    background: linear-gradient(90deg, rgb(169, 210, 236), rgb(165, 202, 225));
        }
    </style>