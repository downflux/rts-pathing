load("@io_bazel_rules_go//go:def.bzl", "go_library", "go_test")

package(default_visibility=["//server:__subpackages__"])

go_library(
    name = "moveable",
    srcs = ["moveable.go"],
    importpath = "github.com/downflux/game/server/entity/component/moveable",
    deps = [
        ":positionable",
        "//engine/id:id",
    ],
)

go_library(
    name = "attackable",
    srcs = ["attackable.go"],
    importpath = "github.com/downflux/game/server/entity/component/attackable",
    deps = [
        ":positionable",
        "//api:data_go_proto",
        "//engine/curve/common:step",
        "//engine/curve/common:timer",
        "//engine/id:id",
        "//server/entity:projectile",
    ],
)

go_library(
    name = "targetable",
    srcs = ["targetable.go"],
    importpath = "github.com/downflux/game/server/entity/component/targetable",
    deps = [
        ":positionable",
        "//engine/id:id",
        "//engine/curve/common:delta",
    ],
)

go_library(
    name = "positionable",
    srcs = ["positionable.go"],
    importpath = "github.com/downflux/game/server/entity/component/positionable",
    deps = [
        "//api:data_go_proto",
        "//engine/curve/common:linearmove",
        "//engine/id:id",
    ],
)
