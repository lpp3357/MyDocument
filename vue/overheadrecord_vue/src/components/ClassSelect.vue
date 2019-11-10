<template>
  <mu-flex align-self="center">
    <mu-flex justify-content="center" align-self="center" class="qo-classSelect-style">
      <mu-select align-self="center" style="width:100%" v-model="mainClassNumber">
        <mu-option
          v-for="opt in listMain"
          :key="opt.numberID"
          :label="opt.valueName"
          :value="opt.numberID"
        ></mu-option>
      </mu-select>
    </mu-flex>
    <mu-flex justify-content="center" align-self="center" class="qo-classSelect-style">
      <mu-select align-self="center" style="width:100%" v-model="subClassNumber">
        <mu-option
          v-for="opt in listSub"
          :key="opt.numberID"
          :label="opt.valueName"
          :value="opt.numberID"
        ></mu-option>
      </mu-select>
    </mu-flex>
    <mu-flex justify-content="center" align-self="center" class="qo-classSelect-style">
      <mu-select align-self="center" style="width:100%" v-model="fromClassNumber">
        <mu-option
          v-for="opt in listFrom"
          :key="opt.numberID"
          :label="opt.valueName"
          :value="opt.numberID"
        ></mu-option>
      </mu-select>
    </mu-flex>
  </mu-flex>
</template>
<script>
import { months } from "moment";
export default {
  data() {
    return {
      listMain: [],
      listSub: [],
      listFrom: [],
      mainClassNumber: "",
      subClassNumber: "",
      fromClassNumber: ""
    };
  },
  methods: {
    //加载主分类
    LoadMainClass() {
      this.$api.post("Class/QueryMainClass", null, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.listMain = r.data;
        if (this.listMain.length == 0) {
          this.mainClassNumber = "";
        } else {
          this.mainClassNumber = this.listMain[0].numberID;
        }
      });
    },
    //加载次分类table
    LoadSubClass() {
      if (this.mainClassNumber == "") return;
      var para = { ParentID: this.mainClassNumber };
      this.$api.post("Class/QuerySubClass", para, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.listSub = r.data;
        if (this.listSub.length == 0) {
          this.subClassNumber = "";
        } else {
          this.subClassNumber = this.listSub[0].numberID;
        }
      });
    },
    //加载从分类table
    LoadFromClass() {
      if (this.subClassNumber == "") return;
      var para = { ParentID: this.subClassNumber };
      this.$api.post("Class/QueryFromClass", para, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.listFrom = r.data;
        if (this.listFrom.length == 0) {
          this.fromClassNumber = "";
        } else {
          this.fromClassNumber = this.listFrom[0].numberID;
        }
      });
    }
  }
};
</script>