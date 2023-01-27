<template>
    {{ this.nickname }}
</template>

<script>
export default {
    name: "user-profile",
    data() {
        return {
            form: {
                nickname: localStorage.getItem('user').nickname,
                name: '',
                lastname: '',
                email: '',
                imgSrc: '',
            }
        }
    }
}
</script>
