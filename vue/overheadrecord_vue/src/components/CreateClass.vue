<template>
  <div>
    <!-- https://muse-ui.org/#/zh-CN/layout -->
    <!-- <h3>创建分类</h3> -->
    <mu-appbar style="width: 100%;padding:0" title="创建分类" color="#90caf9">
      <mu-button icon slot="left" @click="backClick()">
        <mu-icon value="<" color:red></mu-icon>
      </mu-button>
    </mu-appbar>
    <mu-container style="padding:0px;max-width:100%">
      <mu-tabs :value.sync="active" indicator-color="yellow" center full-width class="cc-table">
        <mu-tab>创建主分类</mu-tab>
        <mu-tab>创建次分类</mu-tab>
        <mu-tab>创建从分类</mu-tab>
      </mu-tabs>
      <!-- 主分类选项卡 -->
      <div v-if="active === 0">
        <mu-flex align-self="center">
          <mu-flex class="cc-name-one" align-self="center" style="margin-top:-1.5%">主分类名称：</mu-flex>
          <mu-text-field class="cc-input" v-model="mainClassValue"></mu-text-field>
          <button type="button" class="cc-btn-style" @click="AddMainClass">添加</button>
        </mu-flex>
        <mu-flex>
          <mu-data-table :columns="columns" :data="list" :rowStyle="setStyle" class="cc-table">
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
        <mu-flex align-self="center" style="width:100%">
          <mu-flex class="cc-name-one" justify-content="center">主分类名称：</mu-flex>
          <mu-select class="cc-select-style" v-model="mainClassNumber">
            <mu-option v-for="o in list" :key="o.numberID" :label="o.valueName" :value="o.numberID"></mu-option>
          </mu-select>
          <mu-flex style="width:20%"></mu-flex>
        </mu-flex>
        <mu-flex align-self="center" style="width:100%">
          <mu-flex justify-content="center" align-self="center" class="cc-name-two">次分类名称：</mu-flex>
          <mu-text-field class="cc-input" v-model="SubClassValue"></mu-text-field>
          <button type="button" class="cc-btn-style" @click="AddSubClass">添加</button>
        </mu-flex>
        <mu-flex>
          <mu-data-table :columns="columnsSub" :data="SubT" :rowStyle="setStyle" class="cc-table">
            <template slot-scope="scope">
              <!-- <td style="text-align: center;padding:0">{{scope.row.mainValueName}}</td> -->
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
      <!-- 从分类选项卡 -->
      <div v-if="active === 2">
        <mu-flex align-self="center" style="width:100%">
          <mu-flex class="cc-name-one" justify-content="center">主分类名称：</mu-flex>
          <mu-select class="cc-select-style" v-model="mainClassNumber">
            <mu-option v-for="o in list" :key="o.numberID" :label="o.valueName" :value="o.numberID"></mu-option>
          </mu-select>
          <mu-flex style="width:20%"></mu-flex>
        </mu-flex>
        <mu-flex align-self="center">
          <mu-flex class="cc-name-one" justify-content="center">次分类名称：</mu-flex>
          <mu-select class="cc-select-style" v-model="SubClassNumber">
            <mu-option v-for="o in SubT" :key="o.numberID" :label="o.valueName" :value="o.numberID"></mu-option>
          </mu-select>
          <mu-flex style="width:20%"></mu-flex>
        </mu-flex>
        <mu-flex align-self="center">
          <mu-flex class="cc-name-one" justify-content="center">从分类名称：</mu-flex>
          <mu-text-field class="cc-input" v-model="FromClassValue"></mu-text-field>
          <button type="button" class="cc-btn-style" @click="AddFromClass">添加</button>
        </mu-flex>
        <mu-flex>
          <mu-data-table :columns="columnsFrom" :data="FroT" :rowStyle="setStyle" class="cc-table">
            <template slot-scope="scope">
              <!-- <td style="text-align: center;padding:0">{{scope.row.subValueName}}</td> -->
              <td style="text-align: center;padding:0">{{scope.row.valueName}}</td>
              <td style="text-align: center;padding:0">{{scope.row.state}}</td>
              <td>
                <span
                  class="span-edit"
                  @click="EditFromClass(scope.row.numberID,scope.row.valueName,scope.row.parentID,scope.row.state,1)"
                >编辑</span>
                <span
                  class="span-stop"
                  @click="EditFromClass(scope.row.numberID,scope.row.valueName,scope.row.parentID,scope.row.state,2)"
                >停用</span>
                <span
                  class="span-dele"
                  @click="EditFromClass(scope.row.numberID,scope.row.valueName,scope.row.parentID,scope.row.state,3)"
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
    //获取用户信息
    this.$MyIndex.getUserInfo();
    //绑定主分类列表
    this.LoadMainClass();
  },
  data() {
    return {
      active: 0,
      columns: [
        // 定义选项卡一的table表头
        { title: "主分类名称" },
        { title: "状态", width: 100 },
        { title: "操作", width: 148 }
      ],
      columnsSub: [
        // 定义选项卡二的table表头
        // { title: "主分类名称", width: 100 },
        { title: "次分类名称" },
        { title: "状态", width: 100 },
        { title: "操作", width: 148 }
      ],
      columnsFrom: [
        // 定义选项卡三的table表头
        // { title: "次分类名称", width: 100 },
        { title: "从分类名称" },
        { title: "状态", width: 100 },
        { title: "操作", width: 148 }
      ],
      list: [], //主分类数据集
      SubT: [], //次分类数据集
      FroT: [], //从分类数据集
      mainClassValue: "", //主分类名称
      mainClassNumber: "", //主分类编号
      SubClassValue: "", //次分类名称
      SubClassNumber: "", //次分类编号
      FromClassValue: "" //从分类名称
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
        if (this.list.length == 0) {
          this.mainClassNumber = "";
          return;
        } else {
          this.mainClassNumber = this.list[0].numberID;
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
        this.SubT = r.data;
        if (this.SubT.length == 0) {
          this.SubClassNumber = "";
          return;
        } else {
          this.SubClassNumber = this.SubT[0].numberID;
        }
      });
    },
    //加载从分类table
    LoadFromClass() {
      if (this.SubClassNumber == "") return;
      var para = { ParentID: this.SubClassNumber };
      this.$api.post("Class/QueryFromClass", para, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.FroT = r.data;
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
    },
    //添加从分类
    AddFromClass() {
      var FromClassValue = this.FromClassValue;
      if (FromClassValue == "") {
        this.$Msg.TipAlert("输入从分类名称!");
        return;
      }
      var para = { ValueName: FromClassValue, parentID: this.SubClassNumber };
      this.$api.post(
        "Class/AddFromClass",
        para,
        r => {
          this.$Msg.TipAlert(r.msg);
          this.LoadFromClass();
        },
        m => {
          this.$Msg.TipAlert(m);
        }
      );
    },
    //更新从分类
    EditFromClass(numberID, valueName, parentID, state, type) {
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
        "Class/UpdateFromClass",
        para,
        r => {
          this.$Msg.TipAlert(r.msg);
          this.LoadFromClass();
        },
        m => {
          this.$Msg.TipAlert(m);
        }
      );
    },
    //前往首页
    backClick() {
      this.$router.push({ path: "/?use=" + this.$MyIndex.MyToken });
    }
  },
  watch: {
    mainClassNumber(number, oldNumber) {
      this.mainClassNumber = number;
      //console.log("主分类编号：", number);
      //绑定次分类列表   主分类变更时更新次分类
      this.LoadSubClass();
    },
    SubClassNumber(number, oldNumber) {
      this.SubClassNumber = number;
      //console.log("次分类编号：", number);
      //绑定次分类列表   次分类变更时更新从分类
      this.LoadFromClass();
    }
  }
};
</script>
<style scoped>
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

