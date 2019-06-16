<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
export default {
  name: "App"
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  /* margin-top: 60px; */
}
.mu-input {
  font-size: 16px;
  width: 256px;
  min-height: 48px;
  display: inline-block;
  position: relative;
  color: rgba(0, 0, 0, 0.54);
  padding-bottom: 12px;
  padding-top: 4px;
}
</style>
