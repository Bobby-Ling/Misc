# Makefile
TARGETNAME = hook
OBJ        = $(TARGETNAME).o
MODULE     = $(TARGETNAME).ko
KDIR       = /lib/modules/$(shell uname -r)
PWD    	   = $(shell pwd)
obj-m += $(OBJ)

default:
	make KCONFIG_CONFIG=$(KDIR)/build/config-wsl-modified -j $(shell nproc) -C $(KDIR)/build M=$(PWD) modules 

install:
# @作用是关闭回显 -v: verbose
	@if modprobe -r $(TARGETNAME); then \
		echo ""; \
	else \
		echo ""; \
	fi
	install $(MODULE) $(KDIR)/kernel/drivers/hid
	depmod
	modprobe $(TARGETNAME)

uninstall:
	modprobe -r $(TARGETNAME)

clean:
	make -C $(KDIR)/build M=$(PWD) clean
