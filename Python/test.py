class A:
    global a
    def execute(self):
        global a
        a=2


a=1
aaa=A()
aaa.execute()
print(a)

class B:
    num: int = 0
    def __hash__(self) -> int:
        return self.num
    def __eq__(self, value: object) -> bool:
        if isinstance(value, B):
            return self.num == value.num
        return False

pool = {}
b = B()
b.num = 111
pool[b] = "abc"
pool[None] = "cde"
print(pool)
