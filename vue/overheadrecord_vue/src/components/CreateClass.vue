<template>
  <div>
    <!-- https://muse-ui.org/#/zh-CN/layout -->
    <!-- <h3>创建分类</h3> -->
    <mu-appbar style="width: 100%;" title="创建分类" color="#90caf9"></mu-appbar>
    <mu-container style="padding:0px">
      <mu-tabs :value.sync="active" indicator-color="yellow" center full-width>
        <mu-tab>创建主分类</mu-tab>
        <mu-tab>创建次分类</mu-tab>
      </mu-tabs>
      <!-- 主分类选项卡 -->
      <div v-if="active === 0">
        <mu-flex align-self="center">
          <mu-flex justify-content="center" align-self="center" class="name-style">主分类名称：</mu-flex>
          <mu-text-field fill="true" v-model="mainClassValue"></mu-text-field>
          <button type="button" class="btn-style" @click="AddMainClass">添加</button>
        </mu-flex>
        <mu-flex>
          <mu-data-table :columns="columns" :data="list" :rowStyle="setStyle">
            <template slot-scope="scope">
              <td>{{scope.row.valueName}}</td>
              <td>{{scope.row.state}}</td>
              <td>
                <span
                  class="span-edit"
                  @click="EditMainClass(scope.row.numberID,scope.row.valueName,scope.row.state,1)"
                >编辑</span>
                <span
                  class="span-stop"
                  @click="EditMainClass(scope.row.numberID,scope.row.valueName,scope.row.state,2)"
                >停用</span>
                <span
                  class="span-dele"
                  @click="EditMainClass(scope.row.numberID,scope.row.valueName,scope.row.state,3)"
                >删除</span>
              </td>
            </template>
          </mu-data-table>
        </mu-flex>
      </div>
      <!-- 次分类选项卡 -->
      <div v-if="active === 1">
        <mu-flex align-self="center">
          <mu-flex justify-content="center" align-self="center" class="name-styleSub">主分类名称：</mu-flex>
          <mu-flex justify-content="center" align-self="center">
            <mu-select
              align-self="center"
              style="margin-bottom:-20px;width:205px"
              v-model="mainClassNumber"
              change="SubChangeSelect"
            >
              <mu-option
                v-for="opt in list"
                :key="opt.numberID"
                :label="opt.valueName"
                :value="opt.numberID"
              ></mu-option>
            </mu-select>
          </mu-flex>
        </mu-flex>
        <mu-flex align-self="center">
          <mu-flex justify-content="center" align-self="center" class="name-style">次分类名称：</mu-flex>
          <mu-text-field fill="true" v-model="SubClassValue"></mu-text-field>
          <button type="button" class="btn-style" @click="AddSubClass">添加</button>
        </mu-flex>
        <mu-flex>
          <mu-data-table :columns="columnsSub" :data="listSub" :rowStyle="setStyle">
            <template slot-scope="scope">
              <td style="text-align: center;padding:0">{{scope.row.mainValueName}}</td>
              <td style="text-align: center;padding:0">{{scope.row.valueName}}</td>
              <td style="text-align: center;padding:0">{{scope.row.state}}</td>
              <td>
                <span
                  class="span-edit"
                  @click="EditSubClass(scope.row.numberID,scope.row.valueName,scope.row.parentID,scope.row.state,1)"
                >编辑</span>
                <span
                  class="span-stop"
                  @click="EditSubClass(scope.row.numberID,scope.row.valueName,scope.row.parentID,scope.row.state,2)"
                >停用</span>
                <span
                  class="span-dele"
                  @click="EditSubClass(scope.row.numberID,scope.row.valueName,scope.row.parentID,scope.row.state,3)"
                >删除</span>
              </td>
            </template>
          </mu-data-table>
        </mu-flex>
      </div>
    </mu-container>
  </div>
</template>
<script>
export default {
  created() {
    //绑定主分类列表
    this.LoadMainClass();
  },
  data() {
    return {
      active: 1,
      options: [{ id: 1, text: "一级" }],
      normal: { value1: "111" },
      columns: [
        // 定义选项卡一的table表头
        { title: "主分类名称" },
        { title: "状态", width: 100 },
        { title: "操作", width: 148 }
      ],
      columnsSub: [
        // 定义选项卡二的table表头
        { title: "主分类名称", width: 100 },
        { title: "次分类名称", width: 100 },
        { title: "状态", width: 55 },
        { title: "操作", width: 135 }
      ],
      list: [],
      listSub: [],
      mainClassValue: "", //主分类名称
      mainClassNumber: "", //主分类编号
      SubClassValue: "" //次分类名称
    };
  },
  methods: {
    //设置行样式
    setStyle(rowIndex, row) {
      return "height: 35px;font-size: 1.05em;padding:0";
    },
    //加载主分类
    LoadMainClass() {
      this.$api.post("Class/QueryMainClass", null, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.list = r.data;
        if (this.list.length == 0) return;
        this.mainClassNumber = this.list[0].numberID;
      });
    },
    //加载次分类
    LoadSubClass() {
      var para = { ParentID: this.mainClassNumber };
      this.$api.post("Class/QuerySubClass", para, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.listSub = r.data;
        if (this.listSub.length == 0) return;
      });
    },
    //添加主分类
    AddMainClass() {
      var mainClassValue = this.mainClassValue;
      if (mainClassValue == "") {
        this.$Msg.TipAlert("输入主分类名称!");
        return;
      }
      var para = { ValueName: mainClassValue };
      this.$api.post(
        "Class/AddMainClass",
        para,
        r => {
          this.$Msg.TipAlert(r.msg);
          this.LoadMainClass();
        },
        m => {
          this.$Msg.TipAlert(m);
        }
      );
    },
    //更新主分类
    EditMainClass(numberID, valueName, state, type) {
      if (state == 2 && type == 2) {
        this.$Msg.TipAlert(valueName + " 已停用!");
        return;
      }
      var para = { NumberID: numberID, ValueName: valueName, state: type };
      this.$api.post(
        "Class/UpdateMainClass",
        para,
        r => {
          this.$Msg.TipAlert(r.msg);
          this.LoadMainClass();
        },
        m => {
          this.$Msg.TipAlert(m);
        }
      );
    },
    //添加次分类
    AddSubClass() {
      var SubClassValue = this.SubClassValue;
      if (SubClassValue == "") {
        this.$Msg.TipAlert("输入次分类名称!");
        return;
      }
      var para = { ValueName: SubClassValue, parentID: this.mainClassNumber };
      this.$api.post(
        "Class/AddSubClass",
        para,
        r => {
          this.$Msg.TipAlert(r.msg);
          this.LoadSubClass();
        },
        m => {
          this.$Msg.TipAlert(m);
        }
      );
    },
    //更新次分类
    EditSubClass(numberID, valueName, parentID, state, type) {
      if (state == 2 && type == 2) {
        this.$Msg.TipAlert(valueName + " 已停用!");
        return;
      }
      var para = {
        NumberID: numberID,
        ValueName: valueName,
        parentID: parentID,
        state: type
      };
      this.$api.post(
        "Class/UpdateSubClass",
        para,
        r => {
          this.$Msg.TipAlert(r.msg);
          this.LoadSubClass();
        },
        m => {
          this.$Msg.TipAlert(m);
        }
      );
    }
  },
  watch: {
    mainClassNumber(number, oldNumber) {
      this.mainClassNumber = number;
      console.log(number);
      //绑定次分类列表
      this.LoadSubClass();
    }
  }
};
</script>
<style scoped>
.name-style {
  font-size: 1.05em;
  font-weight: 600;
  margin-top: -5%;
  margin-right: 1%;
  width: 120px;
}
.name-styleSub {
  font-size: 1.05em;
  font-weight: 600;
  margin-top: 3%;
  margin-right: 1.4%;
  width: 90px;
}
.btn-style {
  margin: 10px;
  min-width: 60px;
  min-height: 28px;
  background-color: #2196f3;
  border: none;
  border-radius: 4px;
  -webkit-border-radius: 4px；;
}
.span-edit {
  background-color: #00e676;
  border: none;
  border-radius: 4px;
  -webkit-border-radius: 4px;
  color: #f0f4c3;
}
.span-stop {
  background-color: #ffd54f;
  border: none;
  border-radius: 4px;
  -webkit-border-radius: 4px;
  color: #f0f4c3;
}
.span-dele {
  background-color: #e53935;
  border: none;
  border-radius: 4px;
  -webkit-border-radius: 4px;
  color: #f0f4c3;
}
</style>

