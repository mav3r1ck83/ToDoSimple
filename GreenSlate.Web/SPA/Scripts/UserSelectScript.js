function onSelect(e) {
    $.ajax({
        type: "POST",
        url: '/User/UserSelected',
        data: { User_Name: e.item.text() }
    })
}